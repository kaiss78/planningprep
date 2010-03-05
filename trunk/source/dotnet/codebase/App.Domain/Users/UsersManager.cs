#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Users
 * Purpose: Users entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Jason Duffus	2/18/2010 10:30:11 AM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Transactions;
using App.Data;
using App.Data.Users;
using App.Models.Users;
using App.Core;
using App.Core.Base.Managers;
using App.Core.Exceptions;
using System.Collections.Generic;

namespace App.Domain.Users
{
    public class UsersManager : ManagerBase<User>, IUsersManager
    {
        public UsersManager()
        { }

        #region CRUD Methods
        public override void SaveOrUpdate(User entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(User)", ""))
            {
                try
                {
                    using(TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IUserDAO dao = (IUserDAO) DAOFactory.Get<User>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "UserDAO.SaveOrUpdate(User)");
                }
            } 
        }

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override User Get(long id)
        {
            User user = null;
            try
            {
                using (IUserDAO dao = (IUserDAO) DAOFactory.Get<User>())
                {
                    user = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return user;
        }

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override User Get(long id, bool eagerLoad)
        {
            User user = null;
            try
            {
                using (IUserDAO dao = (IUserDAO)DAOFactory.Get<User>())
                {
                    user = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return user;
        }


        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<User> GetList()
        {
            IEnumerable<User> userList = new List<User>();
            try
            {
                using (IUserDAO dao = (IUserDAO)DAOFactory.Get<User>())
                {
                    userList = dao.GetAll(u => u.Active && !u.Deleted);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return userList;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(User entity)
        {
            bool result = false;
            try
            {
                using (IUserDAO dao = (IUserDAO)DAOFactory.Get<User>())
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
