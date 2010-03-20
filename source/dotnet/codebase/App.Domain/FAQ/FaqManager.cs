
#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Faq
 * Purpose: Faq entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/18/2010 8:10:27 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Core.Base.Managers;
using App.Core.Base.Managers.Responses;
using App.Data.FAQ;
using App.Models.FAQ;
using System.Collections.Generic;
using System.Transactions;
using App.Data;
using App.Core.Exceptions;

namespace App.Domain.FAQ
{
    public interface IFaqManager : IManagerBase<App.Models.FAQ.Faq>
    { }

    public class FaqManager : ManagerBase<App.Models.FAQ.Faq>, IFaqManager
    {
        public FaqManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.FAQ.Faq entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(Faq)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IFaqDAO dao = (IFaqDAO)DAOFactory.Get<Faq>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "FaqDAO.SaveOrUpdate(Faq)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override Faq Get(long id)
        {
            Faq Faq = null;
            try
            {
                using (IFaqDAO dao = (IFaqDAO)DAOFactory.Get<Faq>())
                {
                    Faq = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Faq;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override Faq Get(long id, bool eagerLoad)
        {
            Faq Faq = null;
            try
            {
                using (IFaqDAO dao = (IFaqDAO)DAOFactory.Get<Faq>())
                {
                    Faq = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Faq;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<Faq> GetList()
        {
            IList<Faq> FaqList = new List<Faq>();
            try
            {
                using (IFaqDAO dao = (IFaqDAO)DAOFactory.Get<Faq>())
                {
                    FaqList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return FaqList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<Faq> GetPagedList(int pageNo, int pageLength)
        {
            IList<Faq> FaqList = new List<Faq>();
            try
            {
                using (IFaqDAO dao = (IFaqDAO)DAOFactory.Get<Faq>())
                {
                    FaqList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return FaqList;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.FAQ.Faq entity)
        {
            bool result = false;
            try
            {
                using (IFaqDAO dao = (IFaqDAO)DAOFactory.Get<Faq>())
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
        /// Gets All FAQ Questions Sorted by Category Name
        /// </summary>
        /// <returns></returns>
        public IList<App.Models.FAQ.Faq> GetAllFaqSortByCategory()
        {
            IList<App.Models.FAQ.Faq> faqs = new List<Faq>(); 
            try
            {
                using (IFaqDAO dao = (IFaqDAO)DAOFactory.Get<Faq>())
                {
                    faqs = dao.GetAllFaqSortByCategory();
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return faqs;
        }
        #endregion
    }
}
