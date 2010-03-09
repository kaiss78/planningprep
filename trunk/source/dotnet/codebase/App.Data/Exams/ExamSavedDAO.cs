


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
using App.Models.Exams;

namespace App.Data.Exams
{
    public interface IExamSavedDAO : IDataAccess<App.Models.Exams.ExamSaved>
    {
        IList<App.Models.Exams.ExamSaved> GetSavedExamByExamSessionID(int ExamSessionID);
        ExamSaved GetSavedExamByExamSessionIDAndQuestionID(int ExamSessionID, int QuestionID);
    }

    public class ExamSavedDAO : BaseDataAccess<App.Models.Exams.ExamSaved>, IExamSavedDAO
    {
        #region Constructor
        public ExamSavedDAO()
        {
        }

        public ExamSavedDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Exams.ExamSaved Map(IDataReader reader)
        {
            App.Models.Exams.ExamSaved entity = EntityFactory.Create<App.Models.Exams.ExamSaved>();

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
        public IList<App.Models.Exams.ExamSaved> GetSavedExamByExamSessionID(int ExamSessionID)
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

        /// <summary>
        /// Get Saved Exam for an exam SessionID and QuestionID
        /// </summary>
        /// <param name="ExamSessionID"></param>
        /// <param name="QuestionID"></param>
        /// <returns></returns>
        public ExamSaved GetSavedExamByExamSessionIDAndQuestionID(int ExamSessionID, int QuestionID)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "ExamSavedDAO.GetSavedExamByExamSessionIDAndQuestionID(int,int)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("ExamSessionID", DbType.Int32, ExamSessionID), new DbParameter("QuestionID", DbType.Int32, QuestionID) };

                    return GetInternal("spExamsSavedGetForExamSessionIDAndQuestionID", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "ExamSavedDAO.GetSavedExamByExamSessionIDAndQuestionID(int,int)");
                }
            }
        }


        protected override void EagerLoad(App.Models.Exams.ExamSaved entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
