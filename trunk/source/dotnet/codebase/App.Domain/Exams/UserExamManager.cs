


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		UserExam
 * Purpose: UserExam entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * AFS	3/8/2010 11:21:07 AM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Core.Base.Managers;
using App.Core.Base.Managers.Responses;
using App.Data.UserExams;
using App.Models.UserExams;
using System.Collections.Generic;
using System.Transactions;
using App.Data;
using App.Core.Exceptions;

namespace App.Domain.UserExams
{
    public interface IUserExamManager : IManagerBase<App.Models.UserExams.UserExam>
    { }

    public class UserExamManager : ManagerBase<App.Models.UserExams.UserExam>, IUserExamManager
    {
        public UserExamManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.UserExams.UserExam entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(UserExam)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IUserExamDAO dao = (IUserExamDAO)DAOFactory.Get<UserExam>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "UserExamDAO.SaveOrUpdate(UserExam)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override UserExam Get(long id)
        {
            UserExam UserExam = null;
            try
            {
                using (IUserExamDAO dao = (IUserExamDAO)DAOFactory.Get<UserExam>())
                {
                    UserExam = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return UserExam;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override UserExam Get(long id, bool eagerLoad)
        {
            UserExam UserExam = null;
            try
            {
                using (IUserExamDAO dao = (IUserExamDAO)DAOFactory.Get<UserExam>())
                {
                    UserExam = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return UserExam;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<UserExam> GetList()
        {
            IList<UserExam> UserExamList = new List<UserExam>();
            try
            {
                using (IUserExamDAO dao = (IUserExamDAO)DAOFactory.Get<UserExam>())
                {
                    UserExamList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return UserExamList;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.UserExams.UserExam entity)
        {
            bool result = false;
            try
            {
                using (IUserExamDAO dao = (IUserExamDAO)DAOFactory.Get<UserExam>())
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
