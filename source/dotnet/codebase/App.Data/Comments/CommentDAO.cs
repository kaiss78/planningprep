


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: CommentDAO.cs
 * Purpose: DAO Class to get/set the data from Comment table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/14/2010 03:22:26		Initial Development
 * -------------------------------------------------------------------------------- 
 */
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using App.Models.Enums;
using App.Core;
using App.Core.DB;
using App.Core.Exceptions;
using App.Core.Factories;
using System.Security.Principal;

namespace App.Data.Comments
{
    public interface ICommentDAO : IDataAccess<App.Models.Comments.Comment>
    {
        IList<App.Models.Comments.Comment> GetCommentsByQuestion(int questionID);
    }

    public class CommentDAO : BaseDataAccess<App.Models.Comments.Comment>, ICommentDAO
    {
        #region Constructor
        public CommentDAO()
        {
        }

        public CommentDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Comments.Comment Map(IDataReader reader)
        {
            App.Models.Comments.Comment entity = EntityFactory.Create<App.Models.Comments.Comment>();

            entity.Id = NullHandler.GetInt32(reader["ID"]);
            entity.ID = NullHandler.GetLong(reader["ID"]);
            entity.QuestionID = NullHandler.GetInt(reader["QuestionID"]);
            entity.UserID = NullHandler.GetInt(reader["UserID"]);
            entity.CommentText = NullHandler.GetString(reader["CommentText"]);
            entity.Rank = NullHandler.GetInt(reader["Rank"]);
            entity.Created = NullHandler.GetDateTime(reader["Created"]);
            entity.Modified = NullHandler.GetDateTime(reader["Modified"]);
            entity.NegativeRank = NullHandler.GetInt(reader["NegativeRank"]);
            entity.LinkID = NullHandler.GetInt(reader["LinkID"]);
            return entity;
        }
        /// <summary>
        /// Gets Comments BY Question ID ordered by Rank
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        public IList<App.Models.Comments.Comment> GetCommentsByQuestion(int questionID)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "CommentDAO.GetCommentsByQuestion(int)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("QuestionID", DbType.Int32, questionID) };
                    return GetAllInternal("spGetCommentsByQuestionID", parameters, false);                    
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "CommentDAO.GetCommentsByQuestion(int)");
                }
            }
        }
        protected override void EagerLoad(App.Models.Comments.Comment entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
