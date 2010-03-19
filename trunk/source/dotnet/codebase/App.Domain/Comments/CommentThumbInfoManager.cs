


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		CommentThumbInfo
 * Purpose: CommentThumbInfo entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/19/2010 5:37:16 PM		Initial Code
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
    public interface ICommentThumbInfoManager : IManagerBase<App.Models.Comments.CommentThumbInfo>
    { }

    public class CommentThumbInfoManager : ManagerBase<App.Models.Comments.CommentThumbInfo>, ICommentThumbInfoManager
    {
        public CommentThumbInfoManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.Comments.CommentThumbInfo entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(CommentThumbInfo)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (ICommentThumbInfoDAO dao = (ICommentThumbInfoDAO)DAOFactory.Get<CommentThumbInfo>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "CommentThumbInfoDAO.SaveOrUpdate(CommentThumbInfo)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override CommentThumbInfo Get(long id)
        {
            CommentThumbInfo CommentThumbInfo = null;
            try
            {
                using (ICommentThumbInfoDAO dao = (ICommentThumbInfoDAO)DAOFactory.Get<CommentThumbInfo>())
                {
                    CommentThumbInfo = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return CommentThumbInfo;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override CommentThumbInfo Get(long id, bool eagerLoad)
        {
            CommentThumbInfo CommentThumbInfo = null;
            try
            {
                using (ICommentThumbInfoDAO dao = (ICommentThumbInfoDAO)DAOFactory.Get<CommentThumbInfo>())
                {
                    CommentThumbInfo = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return CommentThumbInfo;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<CommentThumbInfo> GetList()
        {
            IList<CommentThumbInfo> CommentThumbInfoList = new List<CommentThumbInfo>();
            try
            {
                using (ICommentThumbInfoDAO dao = (ICommentThumbInfoDAO)DAOFactory.Get<CommentThumbInfo>())
                {
                    CommentThumbInfoList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return CommentThumbInfoList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<CommentThumbInfo> GetPagedList(int pageNo, int pageLength)
        {
            IList<CommentThumbInfo> CommentThumbInfoList = new List<CommentThumbInfo>();
            try
            {
                using (ICommentThumbInfoDAO dao = (ICommentThumbInfoDAO)DAOFactory.Get<CommentThumbInfo>())
                {
                    CommentThumbInfoList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return CommentThumbInfoList;
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
            try
            {
                using (ICommentThumbInfoDAO dao = (ICommentThumbInfoDAO)DAOFactory.Get<CommentThumbInfo>())
                {
                    return dao.HasThumbed(userID, questionID, commentID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return false;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.Comments.CommentThumbInfo entity)
        {
            bool result = false;
            try
            {
                using (ICommentThumbInfoDAO dao = (ICommentThumbInfoDAO)DAOFactory.Get<CommentThumbInfo>())
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
    }
}
