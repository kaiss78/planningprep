#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		CommentReply
 * Purpose: CommentReply entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/23/2010 10:01:34 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Core.Base.Managers;
using App.Core.Base.Managers.Responses;
using App.Data.Comments;
using App.Models.Comments;
using System.Collections.Generic;
using System.Transactions;
using App.Data;
using App.Core.Exceptions;

namespace App.Domain.Comments
{
    public interface ICommentReplyManager : IManagerBase<App.Models.Comments.CommentReply>
    { }

    public class CommentReplyManager : ManagerBase<App.Models.Comments.CommentReply>, ICommentReplyManager
    {
        public CommentReplyManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.Comments.CommentReply entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(CommentReply)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (ICommentReplyDAO dao = (ICommentReplyDAO)DAOFactory.Get<CommentReply>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "CommentReplyDAO.SaveOrUpdate(CommentReply)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override CommentReply Get(long id)
        {
            CommentReply CommentReply = null;
            try
            {
                using (ICommentReplyDAO dao = (ICommentReplyDAO)DAOFactory.Get<CommentReply>())
                {
                    CommentReply = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return CommentReply;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override CommentReply Get(long id, bool eagerLoad)
        {
            CommentReply CommentReply = null;
            try
            {
                using (ICommentReplyDAO dao = (ICommentReplyDAO)DAOFactory.Get<CommentReply>())
                {
                    CommentReply = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return CommentReply;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<CommentReply> GetList()
        {
            IList<CommentReply> CommentReplyList = new List<CommentReply>();
            try
            {
                using (ICommentReplyDAO dao = (ICommentReplyDAO)DAOFactory.Get<CommentReply>())
                {
                    CommentReplyList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return CommentReplyList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<CommentReply> GetPagedList(int pageNo, int pageLength)
        {
            IList<CommentReply> CommentReplyList = new List<CommentReply>();
            try
            {
                using (ICommentReplyDAO dao = (ICommentReplyDAO)DAOFactory.Get<CommentReply>())
                {
                    CommentReplyList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return CommentReplyList;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.Comments.CommentReply entity)
        {
            bool result = false;
            try
            {
                using (ICommentReplyDAO dao = (ICommentReplyDAO)DAOFactory.Get<CommentReply>())
                {
                    result = dao.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return result;
        }
        #endregion

        /// <summary>
        /// Gets Comment Replyes by the Comment ID. Orderd by Create Date
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns></returns>
        public IList<CommentReply> GetCommentReplyByCommentID(long commentID)
        {
            IList<CommentReply> comments = new List<CommentReply>();
            try
            {
                using (ICommentReplyDAO dao = (ICommentReplyDAO)DAOFactory.Get<CommentReply>())
                {
                    comments = dao.GetCommentReplyByCommentID(commentID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return comments;
        }
    }
}
