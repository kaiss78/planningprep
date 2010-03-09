


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: ExamsSavedDAO.cs
 * Purpose: DAO Class to get/set the data from tblExamsSaved table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/09/2010 23:50:52		Initial Development
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

namespace App.Data.Exams
{
    public interface IExamsSavedDAO : IDataAccess<App.Models.Exams.ExamsSaved>
    {
        IList<App.Models.Exams.ExamsSaved> GetSavedExamByExamSessionID(int ExamSessionID);
    }

    public class ExamsSavedDAO : BaseDataAccess<App.Models.Exams.ExamsSaved>, IExamsSavedDAO
    {
        #region Constructor
        public ExamsSavedDAO()
        {
        }

        public ExamsSavedDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Exams.ExamsSaved Map(IDataReader reader)
        {
            App.Models.Exams.ExamsSaved entity = EntityFactory.Create<App.Models.Exams.ExamsSaved>();

            entity.Id = NullHandler.GetInt32(reader["ID"]);
            entity.ID = NullHandler.GetInt(reader["ID"]);
            entity.UserID = NullHandler.GetInt(reader["UserID"]);
            entity.QuestionID = NullHandler.GetInt(reader["QuestionID"]);
            entity.Answer = NullHandler.GetString(reader["Answer"]);
            entity.TimeStamp = NullHandler.GetDateTime(reader["TimeStamp"]);
            entity.Time = NullHandler.GetInt(reader["Time"]);
            entity.ExamSessionID = NullHandler.GetInt(reader["ExamSessionID"]);

            return entity;
        }

        /// <summary>
        /// Get Saved Exam for an exam SessionID
        /// </summary>
        /// <param name="ExamSessionID"></param>
        /// <returns></returns>
        public IList<App.Models.Exams.ExamsSaved> GetSavedExamByExamSessionID(int ExamSessionID)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "ExamSavedDAO.GetSavedExamByExamSessionID(int)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("ExamSessionID", DbType.String, ExamSessionID) };

                    return GetAllInternal("spExamsSavedGetForExamSessionID", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "ExamSavedDAO.GetSavedExamByExamSessionID(int)");
                }
            }
        }


        protected override void EagerLoad(App.Models.Exams.ExamsSaved entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
