


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: CommentReplyDAO.cs
 * Purpose: DAO Class to get/set the data from CommentReply table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/23/2010 21:59:23		Initial Development
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
using App.Models.Comments;

namespace App.Data.Comments
{
    public interface ICommentReplyDAO : IDataAccess<App.Models.Comments.CommentReply>
    {
        IList<CommentReply> GetCommentReplyByCommentID(long commentID);
    }

    public class CommentReplyDAO : BaseDataAccess<App.Models.Comments.CommentReply>, ICommentReplyDAO
    {
        #region Constructor
        public CommentReplyDAO()
        {
        }

        public CommentReplyDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Comments.CommentReply Map(IDataReader reader)
        {
            App.Models.Comments.CommentReply entity = EntityFactory.Create<App.Models.Comments.CommentReply>();

            entity.Id = NullHandler.GetInt32(reader["ID"]);
            entity.ID = NullHandler.GetLong(reader["ID"]);
            entity.CommentID = NullHandler.GetLong(reader["CommentID"]);
            entity.Message = NullHandler.GetString(reader["Message"]);
            entity.UserID = NullHandler.GetInt(reader["UserID"]);
            entity.Created = NullHandler.GetDateTime(reader["Created"]);

            return entity;
        }
        /// <summary>
        /// Gets Comment Replyes by the Comment ID. Orderd by Create Date
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns></returns>
        public IList<CommentReply> GetCommentReplyByCommentID(long commentID)
        {            
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "CommentReplyDAO.GetCommentReplyByCommentID(long)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("CommentID", DbType.Int64, commentID) };
                    return GetAllInternal("spCommentReplyGetByComment", parameters, false);                    
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "CommentReplyDAO.GetCommentReplyByCommentID(long)");
                }
            }            
        }
        
        protected override void EagerLoad(App.Models.Comments.CommentReply entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
