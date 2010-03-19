


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: ExamStatisticDAO.cs
 * Purpose: DAO Class to get/set the data from ExamStatistic table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/18/2010 00:19:15		Initial Development
 * -------------------------------------------------------------------------------- 
 */
#endregion

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using App.Models.Enums;
using App.Core;
using App.Core.DB;
using App.Core.Exceptions;
using App.Core.Factories;
using System.Security.Principal;
using App.Models.Exams;

namespace App.Data.Exams
{
    public interface IExamStatisticDAO : IDataAccess<App.Models.Exams.ExamStatistic>
    {
        IList<ExamStatistic> GetStatisticsForEthics(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate);
        IList<ExamStatistic> GetTotalExamStatistics(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate);
        IList<ExamStatistic> GetStatisticsForHistoryTheoryLaw(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate);
        IList<ExamStatistic> GetStatisticsForTrendsIssues(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate);
        IList<ExamStatistic> GetStatisticsForPlanMaking(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate);
        IList<ExamStatistic> GetStatisticsForFunctionalTopics(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate);
        IList<ExamStatistic> GetStatisticsForPlanImplementation(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate);
    }

    public class ExamStatisticDAO : BaseDataAccess<App.Models.Exams.ExamStatistic>, IExamStatisticDAO
    {
        #region Constructor
        public ExamStatisticDAO()
        {
        }

        public ExamStatisticDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Exams.ExamStatistic Map(IDataReader reader)
        {
            App.Models.Exams.ExamStatistic entity = EntityFactory.Create<App.Models.Exams.ExamStatistic>();

            entity.Id = NullHandler.GetInt32(reader["UserID"]);
            entity.UserID = NullHandler.GetInt(reader["UserID"]);
            entity.Taken = NullHandler.GetInt(reader["Taken"]);
            entity.Correct = NullHandler.GetInt(reader["Correct"]);
            entity.TotalTime = NullHandler.GetLong(reader["TotalTime"]);

            return entity;
        }
        /// <summary>
        /// Gets Statistics for an User. Gets Filtered or Unfiltered Data
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForEthics(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "ExamStatisticDAO.GetStatisticsForEthics(int, bool, DateTime)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("UserID", DbType.Int32, userId), new DbParameter("IsSearchByDate", DbType.Boolean, isFilterByDate), new DbParameter("StartDate", DbType.DateTime, startDate), new DbParameter("EndDate", DbType.DateTime, endDate) };
                    return GetAllInternal("spGetExamStatisticsForEthiscs", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "CommentDAO.GetCommentsByQuestion(int)");
                }
            }
        }
        /// <summary>
        /// Gets total Exam Statistics for an User filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetTotalExamStatistics(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "ExamStatisticDAO.GetTotalExamStatistics(int, bool, DateTime)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("UserID", DbType.Int32, userId), new DbParameter("IsSearchByDate", DbType.Boolean, isFilterByDate), new DbParameter("StartDate", DbType.DateTime, startDate), new DbParameter("EndDate", DbType.DateTime, endDate) };
                    return GetAllInternal("spGetExamStatisticsTotal", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "CommentDAO.GetCommentsByQuestion(int)");
                }
            }
        }        
        /// <summary>
        /// Gets total Exam Statistics for History Theory Law Category by an User, filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForHistoryTheoryLaw(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "ExamStatisticDAO.GetExamStatisticsForHistoryTheoryLaw(int, bool, DateTime)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("UserID", DbType.Int32, userId), new DbParameter("IsSearchByDate", DbType.Boolean, isFilterByDate), new DbParameter("StartDate", DbType.DateTime, startDate), new DbParameter("EndDate", DbType.DateTime, endDate) };
                    return GetAllInternal("spGetExamStatisticsForHistoryTheoryLaw", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "CommentDAO.GetCommentsByQuestion(int)");
                }
            }
        }
        /// <summary>
        /// Gets Exam Statistics for Trends Issues Category by an User, filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForTrendsIssues(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "ExamStatisticDAO.GetStatisticsForTrendsIssues(int, bool, DateTime)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("UserID", DbType.Int32, userId), new DbParameter("IsSearchByDate", DbType.Boolean, isFilterByDate), new DbParameter("StartDate", DbType.DateTime, startDate), new DbParameter("EndDate", DbType.DateTime, endDate) };
                    return GetAllInternal("spGetExamStatisticsForTrendsIssues", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "CommentDAO.GetCommentsByQuestion(int)");
                }
            }
        }
        /// <summary>
        /// Gets Exam Statistics for Plan Making Category by an User, filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForPlanMaking(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "ExamStatisticDAO.GetStatisticsForPlanMaking(int, bool, DateTime)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("UserID", DbType.Int32, userId), new DbParameter("IsSearchByDate", DbType.Boolean, isFilterByDate), new DbParameter("StartDate", DbType.DateTime, startDate), new DbParameter("EndDate", DbType.DateTime, endDate) };
                    return GetAllInternal("spGetExamStatisticsForPlanMaking", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "CommentDAO.GetCommentsByQuestion(int)");
                }
            }
        }
        /// <summary>
        /// Gets Exam Statistics for Functional Topics Category by an User, filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForFunctionalTopics(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "ExamStatisticDAO.GetStatisticsForForFunctionalTopics(int, bool, DateTime)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("UserID", DbType.Int32, userId), new DbParameter("IsSearchByDate", DbType.Boolean, isFilterByDate), new DbParameter("StartDate", DbType.DateTime, startDate), new DbParameter("EndDate", DbType.DateTime, endDate) };
                    return GetAllInternal("spGetExamStatisticsForFunctionalTopics", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "CommentDAO.GetCommentsByQuestion(int)");
                }
            }
        }
        /// <summary>
        /// Gets Exam Statistics for Plan Implementation Category by an User, filtered or not filtered by date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isFilterByDate"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public IList<ExamStatistic> GetStatisticsForPlanImplementation(int userId, bool isFilterByDate, DateTime startDate, DateTime endDate)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "ExamStatisticDAO.GetStatisticsForPlanImplementation(int, bool, DateTime)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("UserID", DbType.Int32, userId), new DbParameter("IsSearchByDate", DbType.Boolean, isFilterByDate), new DbParameter("StartDate", DbType.DateTime, startDate), new DbParameter("EndDate", DbType.DateTime, endDate) };
                    return GetAllInternal("spGetExamStatisticsForPlanImplementation", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "CommentDAO.GetCommentsByQuestion(int)");
                }
            }
        }
        
        
        protected override void EagerLoad(App.Models.Exams.ExamStatistic entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
