


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Comment
 * Purpose: Comment entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/14/2010 3:24:56 AM		Initial Code
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
    public interface ICommentManager : IManagerBase<App.Models.Comments.Comment>
    { }

    public class CommentManager : ManagerBase<App.Models.Comments.Comment>, ICommentManager
    {
        public CommentManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.Comments.Comment entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(Comment)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (ICommentDAO dao = (ICommentDAO)DAOFactory.Get<Comment>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "CommentDAO.SaveOrUpdate(Comment)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override Comment Get(long id)
        {
            Comment Comment = null;
            try
            {
                using (ICommentDAO dao = (ICommentDAO)DAOFactory.Get<Comment>())
                {
                    Comment = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Comment;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override Comment Get(long id, bool eagerLoad)
        {
            Comment Comment = null;
            try
            {
                using (ICommentDAO dao = (ICommentDAO)DAOFactory.Get<Comment>())
                {
                    Comment = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Comment;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<Comment> GetList()
        {
            IList<Comment> CommentList = new List<Comment>();
            try
            {
                using (ICommentDAO dao = (ICommentDAO)DAOFactory.Get<Comment>())
                {
                    CommentList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return CommentList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<Comment> GetPagedList(int pageNo, int pageLength)
        {
            IList<Comment> CommentList = new List<Comment>();
            try
            {
                using (ICommentDAO dao = (ICommentDAO)DAOFactory.Get<Comment>())
                {
                    CommentList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return CommentList;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.Comments.Comment entity)
        {
            bool result = false;
            try
            {
                using (ICommentDAO dao = (ICommentDAO)DAOFactory.Get<Comment>())
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

        /// <summary>
        /// Gets Comments BY Question ID ordered by Rank
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        public IList<Comment> GetCommentsByQuestion(int questionID)
        {
            IList<Comment> comments = new List<Comment>();
            try
            {
                using (ICommentDAO dao = (ICommentDAO)DAOFactory.Get<Comment>())
                {
                    comments = dao.GetCommentsByQuestion(questionID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return comments;
        }
        #endregion
    }
}
