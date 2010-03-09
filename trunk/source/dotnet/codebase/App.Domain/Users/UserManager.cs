


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		PlanningPrepUser
 * Purpose: PlanningPrepUser entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/8/2010 9:16:13 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Core.Base.Managers;
using App.Core.Base.Managers.Responses;
using App.Data.Users;
using App.Models.Users;
using System.Collections.Generic;
using System.Transactions;
using App.Data;
using App.Core.Exceptions;
using System.Data;

namespace App.Domain.Users
{
    public interface IUserManager : IManagerBase<App.Models.Users.PlanningPrepUser>
    { }

    public class UserManager : ManagerBase<App.Models.Users.PlanningPrepUser>, IUserManager
    {
        public UserManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.Users.PlanningPrepUser entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(PlanningPrepUser)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IUserDAO dao = (IUserDAO)DAOFactory.Get<PlanningPrepUser>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "UserDAO.SaveOrUpdate(PlanningPrepUser)");
                }
            }
        }

      
        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override PlanningPrepUser Get(long id)
        {
            PlanningPrepUser PlanningPrepUser = null;
            try
            {
                using (IUserDAO dao = (IUserDAO)DAOFactory.Get<PlanningPrepUser>())
                {
                    PlanningPrepUser = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return PlanningPrepUser;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override PlanningPrepUser Get(long id, bool eagerLoad)
        {
            PlanningPrepUser PlanningPrepUser = null;
            try
            {
                using (IUserDAO dao = (IUserDAO)DAOFactory.Get<PlanningPrepUser>())
                {
                    PlanningPrepUser = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return PlanningPrepUser;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<PlanningPrepUser> GetList()
        {
            IList<PlanningPrepUser> UserList = new List<PlanningPrepUser>();
            try
            {
                using (IUserDAO dao = (IUserDAO)DAOFactory.Get<PlanningPrepUser>())
                {
                    UserList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return UserList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<PlanningPrepUser> GetPagedList(int pageNo, int pageLength)
        {
            IList<PlanningPrepUser> UserList = new List<PlanningPrepUser>();
            try
            {
                using (IUserDAO dao = (IUserDAO)DAOFactory.Get<PlanningPrepUser>())
                {
                    UserList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return UserList;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.Users.PlanningPrepUser entity)
        {
            bool result = false;
            try
            {
                using (IUserDAO dao = (IUserDAO)DAOFactory.Get<PlanningPrepUser>())
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
        /// Gets user object by userName and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public PlanningPrepUser GetUserByUserNamePassword(string userName, string password)
        {
            PlanningPrepUser PlanningPrepUser = null;
            try
            {
                using (IUserDAO dao = (IUserDAO)DAOFactory.Get<PlanningPrepUser>())
                {
                    PlanningPrepUser = dao.GetUserByUserNamePassword(userName, password);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return PlanningPrepUser;
        }

        /// <summary>
        /// Gets user object by userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public PlanningPrepUser GetUserByUserName(string userName)
        {
            PlanningPrepUser PlanningPrepUser = null;
            try
            {
                using (IUserDAO dao = (IUserDAO)DAOFactory.Get<PlanningPrepUser>())
                {
                    PlanningPrepUser = dao.GetUserByUserName(userName);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return PlanningPrepUser;
        }
        #endregion
    }
}
