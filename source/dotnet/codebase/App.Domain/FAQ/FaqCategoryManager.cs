


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		FaqCategory
 * Purpose: FaqCategory entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/18/2010 8:01:19 PM		Initial Code
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
    public interface IFaqCategoryManager : IManagerBase<App.Models.FAQ.FaqCategory>
    { }

    public class FaqCategoryManager : ManagerBase<App.Models.FAQ.FaqCategory>, IFaqCategoryManager
    {
        public FaqCategoryManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.FAQ.FaqCategory entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(FaqCategory)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IFaqCategoryDAO dao = (IFaqCategoryDAO)DAOFactory.Get<FaqCategory>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "FaqCategoryDAO.SaveOrUpdate(FaqCategory)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override FaqCategory Get(long id)
        {
            FaqCategory FaqCategory = null;
            try
            {
                using (IFaqCategoryDAO dao = (IFaqCategoryDAO)DAOFactory.Get<FaqCategory>())
                {
                    FaqCategory = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return FaqCategory;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override FaqCategory Get(long id, bool eagerLoad)
        {
            FaqCategory FaqCategory = null;
            try
            {
                using (IFaqCategoryDAO dao = (IFaqCategoryDAO)DAOFactory.Get<FaqCategory>())
                {
                    FaqCategory = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return FaqCategory;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<FaqCategory> GetList()
        {
            IList<FaqCategory> FaqCategoryList = new List<FaqCategory>();
            try
            {
                using (IFaqCategoryDAO dao = (IFaqCategoryDAO)DAOFactory.Get<FaqCategory>())
                {
                    FaqCategoryList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return FaqCategoryList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<FaqCategory> GetPagedList(int pageNo, int pageLength)
        {
            IList<FaqCategory> FaqCategoryList = new List<FaqCategory>();
            try
            {
                using (IFaqCategoryDAO dao = (IFaqCategoryDAO)DAOFactory.Get<FaqCategory>())
                {
                    FaqCategoryList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return FaqCategoryList;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.FAQ.FaqCategory entity)
        {
            bool result = false;
            try
            {
                using (IFaqCategoryDAO dao = (IFaqCategoryDAO)DAOFactory.Get<FaqCategory>())
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
