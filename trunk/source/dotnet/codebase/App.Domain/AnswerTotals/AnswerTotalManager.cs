


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		AnswerTotal
 * Purpose: AnswerTotal entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/11/2010 1:04:21 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Core.Base.Managers;
using App.Core.Base.Managers.Responses;
using App.Data.AnswerTotals;
using App.Models.AnswerTotals;
using System.Collections.Generic;
using System.Transactions;
using App.Data;
using App.Core.Exceptions;

namespace App.Domain.AnswerTotals
{
    public interface IAnswerTotalManager : IManagerBase<App.Models.AnswerTotals.AnswerTotal>
    { }

    public class AnswerTotalManager : ManagerBase<App.Models.AnswerTotals.AnswerTotal>, IAnswerTotalManager
    {
        public AnswerTotalManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.AnswerTotals.AnswerTotal entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(AnswerTotal)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IAnswerTotalDAO dao = (IAnswerTotalDAO)DAOFactory.Get<AnswerTotal>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "AnswerTotalDAO.SaveOrUpdate(AnswerTotal)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override AnswerTotal Get(long id)
        {
            AnswerTotal AnswerTotal = null;
            try
            {
                using (IAnswerTotalDAO dao = (IAnswerTotalDAO)DAOFactory.Get<AnswerTotal>())
                {
                    AnswerTotal = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return AnswerTotal;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override AnswerTotal Get(long id, bool eagerLoad)
        {
            AnswerTotal AnswerTotal = null;
            try
            {
                using (IAnswerTotalDAO dao = (IAnswerTotalDAO)DAOFactory.Get<AnswerTotal>())
                {
                    AnswerTotal = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return AnswerTotal;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<AnswerTotal> GetList()
        {
            IList<AnswerTotal> AnswerTotalList = new List<AnswerTotal>();
            try
            {
                using (IAnswerTotalDAO dao = (IAnswerTotalDAO)DAOFactory.Get<AnswerTotal>())
                {
                    AnswerTotalList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return AnswerTotalList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<AnswerTotal> GetPagedList(int pageNo, int pageLength)
        {
            IList<AnswerTotal> AnswerTotalList = new List<AnswerTotal>();
            try
            {
                using (IAnswerTotalDAO dao = (IAnswerTotalDAO)DAOFactory.Get<AnswerTotal>())
                {
                    AnswerTotalList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return AnswerTotalList;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.AnswerTotals.AnswerTotal entity)
        {
            bool result = false;
            try
            {
                using (IAnswerTotalDAO dao = (IAnswerTotalDAO)DAOFactory.Get<AnswerTotal>())
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
