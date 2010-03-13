


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Questions
 * Purpose: Questions entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/8/2010 9:36:56 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Core.Base.Managers;
using App.Core.Base.Managers.Responses;
using App.Data.Questions;
using App.Models.Questions;
using System.Collections.Generic;
using System.Transactions;
using App.Data;
using App.Core.Exceptions;

namespace App.Domain.Questions
{
    public interface IQuestionsManager : IManagerBase<App.Models.Questions.Questions>
    { }

    public class QuestionsManager : ManagerBase<App.Models.Questions.Questions>, IQuestionsManager
    {
        public QuestionsManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.Questions.Questions entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(Questions)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IQuestionsDAO dao = (IQuestionsDAO)DAOFactory.Get<App.Models.Questions.Questions>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "QuestionsDAO.SaveOrUpdate(Questions)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override App.Models.Questions.Questions Get(long id)
        {
            App.Models.Questions.Questions Questions = null;
            try
            {
                using (IQuestionsDAO dao = (IQuestionsDAO)DAOFactory.Get<App.Models.Questions.Questions>())
                {
                    Questions = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Questions;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override App.Models.Questions.Questions Get(long id, bool eagerLoad)
        {
            App.Models.Questions.Questions Questions = null;
            try
            {
                using (IQuestionsDAO dao = (IQuestionsDAO)DAOFactory.Get<App.Models.Questions.Questions>())
                {
                    Questions = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Questions;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<App.Models.Questions.Questions> GetList()
        {
            IList<App.Models.Questions.Questions> QuestionsList = new List<App.Models.Questions.Questions>();
            try
            {
                using (IQuestionsDAO dao = (IQuestionsDAO)DAOFactory.Get<App.Models.Questions.Questions>())
                {
                    QuestionsList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return QuestionsList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<App.Models.Questions.Questions> GetPagedList(int pageNo, int pageLength)
        {
            IList<App.Models.Questions.Questions> QuestionsList = new List<App.Models.Questions.Questions>();
            try
            {
                using (IQuestionsDAO dao = (IQuestionsDAO)DAOFactory.Get<App.Models.Questions.Questions>())
                {
                    QuestionsList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return QuestionsList;
        }

        /// <summary>
        /// Get paginated data by Keyword or Category
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<App.Models.Questions.Questions> GetPagedListByKeywordOrCategory(int pageNo, int pageLength,string keyword, string category,bool filter)
        {
            IList<App.Models.Questions.Questions> QuestionsList = new List<App.Models.Questions.Questions>();
            try
            {
                using (IQuestionsDAO dao = (IQuestionsDAO)DAOFactory.Get<App.Models.Questions.Questions>())
                {
                    QuestionsList = dao.GetPagedListByKeywordOrCategory(pageNo,pageLength,keyword,category,filter);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return QuestionsList;
        }
        /// <summary>
        /// Gets Last Question Update Date
        /// </summary>
        /// <returns></returns>
        public DateTime LastQuestionDate()
        {
            DateTime lastQuestionDate = DateTime.Now;
            try
            {
                using (IQuestionsDAO dao = (IQuestionsDAO)DAOFactory.Get<App.Models.Questions.Questions>())
                {
                    lastQuestionDate = dao.LastQuestionDate();
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return lastQuestionDate;
        }
        /// <summary>
        /// Processes Question of the Week Answer
        /// </summary>
        /// <param name="questionID"></param>
        /// <param name="userId"></param>
        /// <param name="answer"></param>
        public void SaveQuestionOfTheWeekAnswer(int questionID, int userID, String answer)
        {
            try
            {
                using (IQuestionsDAO dao = (IQuestionsDAO)DAOFactory.Get<App.Models.Questions.Questions>())
                {
                    dao.SaveQuestionOfTheWeekAnswer(questionID, userID, answer);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.Questions.Questions entity)
        {
            bool result = false;
            try
            {
                using (IQuestionsDAO dao = (IQuestionsDAO)DAOFactory.Get<App.Models.Questions.Questions>())
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
        /// Get Question links
        /// </summary>
        /// <param name="QuestionID"></param>
        /// <returns></returns>
        public IList<QuestionLink> GetQuestionLinks(int QuestionID)
        {
            IList<QuestionLink> QuestionsLinkList = new List<QuestionLink>();
            try
            {
                using (IQuestionLinkDAO dao = (IQuestionLinkDAO)DAOFactory.Get<App.Models.Questions.QuestionLink>())
                {
                    QuestionsLinkList = dao.GetQuestionLinks(QuestionID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return QuestionsLinkList;
        }

        #endregion
    }
}
