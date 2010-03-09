


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
 * Shubho	3/8/2010 4:17:45 PM		Initial Code
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
using App.Models.Exams;
using App.Data.Exams;

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
        /// Saves or Updates the Question's answer in the database
        /// </summary>
        /// <param name="entity"></param>
        public void SaveOrUpdateSavedQuestion(App.Models.Exams.ExamSaved entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(ExamSaved)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IExamSavedDAO dao = (IExamSavedDAO)DAOFactory.Get<ExamSaved>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "ExamSavedDAO.SaveOrUpdate(ExamSaved)");
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
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<UserExam> GetPagedList(int pageNo, int pageLength)
        {
            IList<UserExam> UserExamList = new List<UserExam>();
            try
            {
                using (IUserExamDAO dao = (IUserExamDAO)DAOFactory.Get<UserExam>())
                {
                    UserExamList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
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

        #region Other Methods

        /// <summary>
        /// Get question list for exam type
        /// </summary>
        /// <param name="examType"></param>
        /// <returns></returns>
        public IList<QuestionForExamType> GetQuestionsForExamType(int examType)
        {
            IList<QuestionForExamType> UserExamList = new List<QuestionForExamType>();
            try
            {
                using (IQuestionForExamTypeDAO dao = (IQuestionForExamTypeDAO)DAOFactory.Get<QuestionForExamType>())
                {
                    UserExamList = dao.GetQuestionsForExamType(examType);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return UserExamList;
        }


        /// <summary>
        /// Get Exam sessions for an exam type and UserID
        /// </summary>
        /// <param name="examType"></param>
        /// <returns></returns>
        public IList<UserExam> GetUserExamByExamAndUser(int ExamID, int UserID)
        {
            IList<UserExam> UserExamList = new List<UserExam>();
            try
            {
                using (IUserExamDAO dao = (IUserExamDAO)DAOFactory.Get<UserExam>())
                {
                    UserExamList = dao.GetUserExamByExamAndUser(ExamID, UserID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return UserExamList;
        }

        /// <summary>
        /// Get Exam sessions for an exam SessionID
        /// </summary>
        /// <param name="examType"></param>
        /// <returns></returns>
        public IList<App.Models.Exams.ExamSaved> GetSavedExamsByExamSessionID(int ExamSessionID)
        {
            IList<App.Models.Exams.ExamSaved> SavedExamList = new List<App.Models.Exams.ExamSaved>();
            try
            {
                using (App.Data.Exams.IExamSavedDAO dao = (App.Data.Exams.IExamSavedDAO)DAOFactory.Get<App.Models.Exams.ExamSaved>())
                {
                    SavedExamList = dao.GetSavedExamByExamSessionID(ExamSessionID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return SavedExamList;
        }

        /// <summary>
        /// Get Saved Exam for an exam SessionID and QuestionID
        /// </summary>
        /// <param name="ExamSessionID"></param>
        /// <param name="QuestionID"></param>
        /// <returns></returns>
        public ExamSaved GetSavedExamByExamSessionIDAndQuestionID(int ExamSessionID, int QuestionID)
        {
            ExamSaved UserExam = null;
            try
            {
                using (IExamSavedDAO dao = (IExamSavedDAO)DAOFactory.Get<ExamSaved>())
                {
                    UserExam = dao.GetSavedExamByExamSessionIDAndQuestionID(ExamSessionID, QuestionID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return UserExam;
        }
        #endregion
    }
}
