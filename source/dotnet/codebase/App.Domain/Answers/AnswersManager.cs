


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Answers
 * Purpose: Answers entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/14/2010 4:10:12 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Core.Base.Managers;
using App.Core.Base.Managers.Responses;
using App.Data.Answers;
using App.Models.Answers;
using System.Collections.Generic;
using System.Transactions;
using App.Data;
using App.Core.Exceptions;

namespace App.Domain.Answer
{
    public interface IAnswersManager : IManagerBase<App.Models.Answers.Answers>
    { }

    public class AnswersManager : ManagerBase<App.Models.Answers.Answers>, IAnswersManager
    {
        public AnswersManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.Answers.Answers entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(Answers)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IAnswersDAO dao = (IAnswersDAO)DAOFactory.Get<Answers>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "AnswersDAO.SaveOrUpdate(Answers)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override Answers Get(long id)
        {
            Answers Answers = null;
            try
            {
                using (IAnswersDAO dao = (IAnswersDAO)DAOFactory.Get<Answers>())
                {
                    Answers = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Answers;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override Answers Get(long id, bool eagerLoad)
        {
            Answers Answers = null;
            try
            {
                using (IAnswersDAO dao = (IAnswersDAO)DAOFactory.Get<Answers>())
                {
                    Answers = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Answers;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<Answers> GetList()
        {
            IList<Answers> AnswersList = new List<Answers>();
            try
            {
                using (IAnswersDAO dao = (IAnswersDAO)DAOFactory.Get<Answers>())
                {
                    AnswersList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return AnswersList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<Answers> GetPagedList(int pageNo, int pageLength)
        {
            IList<Answers> AnswersList = new List<Answers>();
            try
            {
                using (IAnswersDAO dao = (IAnswersDAO)DAOFactory.Get<Answers>())
                {
                    AnswersList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return AnswersList;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.Answers.Answers entity)
        {
            bool result = false;
            try
            {
                using (IAnswersDAO dao = (IAnswersDAO)DAOFactory.Get<Answers>())
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
        /// Deletes all saved answers by UserID which were answered for a question by question answers
        /// (Not answered for an exam)
        /// </summary>
        /// <param name="entity">The UserID.</param>
        /// <returns></returns>
        public bool DeleteByUserID(int UserID)
        {
            bool result = false;
            try
            {
                using (IAnswersDAO dao = (IAnswersDAO)DAOFactory.Get<Answers>())
                {
                    result = dao.DeleteByUserID(UserID);
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
