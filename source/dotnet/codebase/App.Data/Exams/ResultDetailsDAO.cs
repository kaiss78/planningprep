


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: ResultDetailsDAO.cs
 * Purpose: DAO Class to get/set the data from ResultDetails table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/12/2010 00:42:39		Initial Development
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
    public interface IResultDetailsDAO : IDataAccess<App.Models.Exams.ResultDetails>
    {
        IList<ResultDetails> GetResultDetailsByExamSessionID(int ExamSessionID);
    }

    public class ResultDetailsDAO : BaseDataAccess<App.Models.Exams.ResultDetails>, IResultDetailsDAO
    {
        #region Constructor
        public ResultDetailsDAO()
        {
        }

        public ResultDetailsDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Exams.ResultDetails Map(IDataReader reader)
        {
            App.Models.Exams.ResultDetails entity = EntityFactory.Create<App.Models.Exams.ResultDetails>();

            entity.Id = NullHandler.GetInt32(reader["QuestionID"]);
            entity.QuestionID = NullHandler.GetInt(reader["QuestionID"]);
            entity.Question = NullHandler.GetString(reader["Question"]);
            entity.CorrectAnswer = NullHandler.GetString(reader["CorrectAnswer"]);
            entity.YourAnswer = NullHandler.GetString(reader["YourAnswer"]);
            
            return entity;
        }

        /// <summary>
        /// Get ResultDetails for ExamSessionID
        /// </summary>
        /// <param name="ExamSessionID"></param>
        /// <returns></returns>
        public IList<ResultDetails> GetResultDetailsByExamSessionID(int ExamSessionID)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "ResultDetailsDAO.GetResultDetailsByExamSessionID(int)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("ExamSessionID", DbType.Int32, ExamSessionID)};

                    return GetAllInternal("spResultDetailsForExamSession", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "ResultDetailsDAO.GetResultDetailsByExamSessionID(int)");
                }
            }
        }

        protected override void EagerLoad(App.Models.Exams.ResultDetails entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
