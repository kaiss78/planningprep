


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		ExamStatistic
 * Purpose: ExamStatistic entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/18/2010 12:27:33 AM		Initial Code
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
    public interface IExamStatisticManager : IManagerBase<App.Models.Exams.ExamStatistic>
    { }

    public class ExamStatisticManager : ManagerBase<App.Models.Exams.ExamStatistic>, IExamStatisticManager
    {
        public ExamStatisticManager()
        { }

        #region CRUD Methods
        /// <summary>
        /// Saves or Updates the entity in the database
        /// </summary>
        /// <param name="entity"></param>
        public override void SaveOrUpdate(App.Models.Exams.ExamStatistic entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(ExamStatistic)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "ExamStatisticDAO.SaveOrUpdate(ExamStatistic)");
                }
            }
        }

        /// <summary>
        /// Gets the object with specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override ExamStatistic Get(long id)
        {
            ExamStatistic ExamStatistic = null;
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                {
                    ExamStatistic = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamStatistic;
        }

        /// <summary>
        /// Gets the object with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override ExamStatistic Get(long id, bool eagerLoad)
        {
            ExamStatistic ExamStatistic = null;
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                {
                    ExamStatistic = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamStatistic;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IList<ExamStatistic> GetList()
        {
            IList<ExamStatistic> ExamStatisticList = new List<ExamStatistic>();
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                {
                    ExamStatisticList = dao.GetAll(u => u.Id > 0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamStatisticList;
        }

        /// <summary>
        /// Get paginated data
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetPagedList(int pageNo, int pageLength)
        {
            IList<ExamStatistic> ExamStatisticList = new List<ExamStatistic>();
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                {
                    ExamStatisticList = dao.GetPagedList(u => u.Id > 0, pageNo, pageLength);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamStatisticList;
        }
        /// <summary>
        /// Gets Statistics for an User. Gets Filtered or Unfiltered Data
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForEthics(int userId, bool isFilterByDate, DateTime filterDate)
        {
            IList<ExamStatistic> ExamStatisticList = new List<ExamStatistic>();
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                {
                    ExamStatisticList = dao.GetStatisticsForEthics(userId, isFilterByDate, filterDate);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamStatisticList;
        }

        /// <summary>
        /// Gets total Exam Statistics for an User filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetTotalExamStatistics(int userId, bool isFilterByDate, DateTime filterDate)
        {
            IList<ExamStatistic> ExamStatisticList = new List<ExamStatistic>();
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                {
                    ExamStatisticList = dao.GetTotalExamStatistics(userId, isFilterByDate, filterDate);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamStatisticList;
        }
        /// <summary>
        /// Gets Exam Statistics for Trends Issues Category by an User, filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForHistoryTheoryLaw(int userId, bool isFilterByDate, DateTime filterDate)
        {
            IList<ExamStatistic> ExamStatisticList = new List<ExamStatistic>();
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                {
                    ExamStatisticList = dao.GetStatisticsForHistoryTheoryLaw(userId, isFilterByDate, filterDate);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamStatisticList;
        }
        /// <summary>
        /// Gets Exam Statistics for Trends Issues Category by an User, filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForTrendsIssues(int userId, bool isFilterByDate, DateTime filterDate)
        {
            IList<ExamStatistic> ExamStatisticList = new List<ExamStatistic>();
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                {
                    ExamStatisticList = dao.GetStatisticsForTrendsIssues(userId, isFilterByDate, filterDate);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamStatisticList;
        }
        /// <summary>
        /// Gets Exam Statistics for Plan Making Category by an User, filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForPlanMaking(int userId, bool isFilterByDate, DateTime filterDate)
        {
            IList<ExamStatistic> ExamStatisticList = new List<ExamStatistic>();
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                {
                    ExamStatisticList = dao.GetStatisticsForPlanMaking(userId, isFilterByDate, filterDate);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamStatisticList;
        }

        /// <summary>
        /// Gets Exam Statistics for Functional Topics Category by an User, filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForFunctionalTopics(int userId, bool isFilterByDate, DateTime filterDate)
        {
            IList<ExamStatistic> ExamStatisticList = new List<ExamStatistic>();
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                {
                    ExamStatisticList = dao.GetStatisticsForFunctionalTopics(userId, isFilterByDate, filterDate);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamStatisticList;
        }
        /// <summary>
        /// Gets Exam Statistics for Plan Implementation Category by an User, filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForPlanImplementation(int userId, bool isFilterByDate, DateTime filterDate)
        {
            IList<ExamStatistic> ExamStatisticList = new List<ExamStatistic>();
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
                {
                    ExamStatisticList = dao.GetStatisticsForPlanImplementation(userId, isFilterByDate, filterDate);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ExamStatisticList;
        }
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(App.Models.Exams.ExamStatistic entity)
        {
            bool result = false;
            try
            {
                using (IExamStatisticDAO dao = (IExamStatisticDAO)DAOFactory.Get<ExamStatistic>())
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
