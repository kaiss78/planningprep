


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Links
 * Purpose: Links entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/11/2010 3:51:59 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Core.Base.Managers;
using App.Core.Base.Managers.Responses;
using App.Data.Links;
using App.Models.Links;
using System.Collections.Generic;
using System.Transactions;
using App.Data;
using App.Core.Exceptions;

namespace App.Domain.Links
{
    public interface ILinkManager : IManagerBase<App.Models.Links.Link>
    { }

    public class LinkManager : ManagerBase<App.Models.Links.Link>, ILinkManager
    {
        public LinkManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.Links.Link entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(Links)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (ILinkDAO dao = (ILinkDAO)DAOFactory.Get<Link>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "LinksDAO.SaveOrUpdate(Links)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override Link Get(long id)
        {
            Link Links = null;
            try
            {
                using (ILinkDAO dao = (ILinkDAO)DAOFactory.Get<Link>())
                {
                    Links = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Links;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override Link Get(long id, bool eagerLoad)
        {
            Link Links = null;
            try
            {
                using (ILinkDAO dao = (ILinkDAO)DAOFactory.Get<Link>())
                {
                    Links = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Links;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<Link> GetList()
        {
            IList<Link> LinksList = new List<Link>();
            try
            {
                using (ILinkDAO dao = (ILinkDAO)DAOFactory.Get<Link>())
                {
                    LinksList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return LinksList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<Link> GetPagedList(int pageNo, int pageLength)
        {
            IList<Link> LinksList = new List<Link>();
            try
            {
                using (ILinkDAO dao = (ILinkDAO)DAOFactory.Get<Link>())
                {
                    LinksList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return LinksList;
        }
        /// <summary>
        /// Gets Links for a Question by Question ID
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        public IList<App.Models.Links.Link> GetLinksForQuestion(int questionID)
        {
            IList<Link> links = new List<Link>();
            try
            {
                using (ILinkDAO dao = (ILinkDAO)DAOFactory.Get<Link>())
                {
                    links = dao.GetLinksForQuestion(questionID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return links;
        }
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.Links.Link entity)
        {
            bool result = false;
            try
            {
                using (ILinkDAO dao = (ILinkDAO)DAOFactory.Get<Link>())
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
