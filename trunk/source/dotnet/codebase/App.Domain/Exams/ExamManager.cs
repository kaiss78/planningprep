


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Exam
 * Purpose: Exam entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/9/2010 9:25:15 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Core.Base.Managers;
using App.Core.Base.Managers.Responses;
using App.Data.Exams;
using App.Models.Exams;
using System.Collections.Generic;
using System.Transactions;
using App.Data;
using App.Core.Exceptions;

namespace App.Domain.Exams
{
    public interface IExamManager : IManagerBase<App.Models.Exams.Exam>
    { }

    public class ExamManager : ManagerBase<App.Models.Exams.Exam>, IExamManager
    {
        public ExamManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.Exams.Exam entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(Exam)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IExamDAO dao = (IExamDAO)DAOFactory.Get<Exam>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "ExamDAO.SaveOrUpdate(Exam)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override Exam Get(long id)
        {
            Exam Exam = null;
            try
            {
                using (IExamDAO dao = (IExamDAO)DAOFactory.Get<Exam>())
                {
                    Exam = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Exam;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override Exam Get(long id, bool eagerLoad)
        {
            Exam Exam = null;
            try
            {
                using (IExamDAO dao = (IExamDAO)DAOFactory.Get<Exam>())
                {
                    Exam = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Exam;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<Exam> GetList()
        {
            IList<Exam> ExamList = new List<Exam>();
            try
            {
                using (IExamDAO dao = (IExamDAO)DAOFactory.Get<Exam>())
                {
                    ExamList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<Exam> GetPagedList(int pageNo, int pageLength)
        {
            IList<Exam> ExamList = new List<Exam>();
            try
            {
                using (IExamDAO dao = (IExamDAO)DAOFactory.Get<Exam>())
                {
                    ExamList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamList;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.Exams.Exam entity)
        {
            bool result = false;
            try
            {
                using (IExamDAO dao = (IExamDAO)DAOFactory.Get<Exam>())
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
