


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: CommentThumbInfoDAO.cs
 * Purpose: DAO Class to get/set the data from CommentThumbInfo table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/19/2010 17:34:49		Initial Development
 * -------------------------------------------------------------------------------- 
 */
#endregion

using System;
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
    public interface ICommentThumbInfoDAO : IDataAccess<App.Models.Comments.CommentThumbInfo>
    {
        bool HasThumbed(int userID, int questionID, long commentID);
    }

    public class CommentThumbInfoDAO : BaseDataAccess<App.Models.Comments.CommentThumbInfo>, ICommentThumbInfoDAO
    {
        #region Constructor
        public CommentThumbInfoDAO()
        {
        }

        public CommentThumbInfoDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Comments.CommentThumbInfo Map(IDataReader reader)
        {
            App.Models.Comments.CommentThumbInfo entity = EntityFactory.Create<App.Models.Comments.CommentThumbInfo>();

            entity.Id = NullHandler.GetInt32(reader["ID"]);
            entity.ID = NullHandler.GetLong(reader["ID"]);
            entity.CommentID = NullHandler.GetLong(reader["CommentID"]);
            entity.UserID = NullHandler.GetInt(reader["UserID"]);
            entity.QuestionID = NullHandler.GetInt(reader["QuestionID"]);
            entity.Created = NullHandler.GetDateTime(reader["Created"]);

            return entity;
        }
        /// <summary>
        /// Checks Whether an User has Thumbs Up on a Comment for a Question
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="questionID"></param>
        /// <param name="commentID"></param>
        /// <returns></returns>
        public bool HasThumbed(int userID, int questionID, long commentID)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "CommentThumbInfoDAO.HasThumbed(int, int, long)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("QuestionID", DbType.Int32, questionID), new DbParameter("UserID", DbType.Int32, userID), new DbParameter("CommentId", DbType.Int64, commentID) };
                    App.Models.Comments.CommentThumbInfo thumbInfo = GetInternal("spCommentThumbInfoGetByCommentUserAndQuestion", parameters, false);
                    return thumbInfo == null ? false : true;
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "CommentDAO.GetCommentsByQuestion(int)");
                }
            }
        }

        protected override void EagerLoad(App.Models.Comments.CommentThumbInfo entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
