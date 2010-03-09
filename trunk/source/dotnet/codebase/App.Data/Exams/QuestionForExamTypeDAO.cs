


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: QuestionForExamTypeDAO.cs
 * Purpose: DAO Class to get/set the data from QuestionForExamType table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/09/2010 10:22:23		Initial Development
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
    public interface IQuestionForExamTypeDAO : IDataAccess<App.Models.Exams.QuestionForExamType>
    {
        IList<QuestionForExamType> GetQuestionsForExamType(int examType);
    }

    public class QuestionForExamTypeDAO : BaseDataAccess<App.Models.Exams.QuestionForExamType>, IQuestionForExamTypeDAO
    {
        #region Constructor
        public QuestionForExamTypeDAO()
        {
        }

        public QuestionForExamTypeDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Exams.QuestionForExamType Map(IDataReader reader)
        {
            App.Models.Exams.QuestionForExamType entity = EntityFactory.Create<App.Models.Exams.QuestionForExamType>();

            entity.Id = NullHandler.GetInt32(reader["ID"]);
            entity.ID = NullHandler.GetInt(reader["ID"]);
            entity.ExamID = NullHandler.GetInt(reader["ExamID"]);
            entity.QuestionID = NullHandler.GetInt(reader["QuestionID"]);
            entity.Question = NullHandler.GetString(reader["Question"]);
            entity.AnswerA = NullHandler.GetString(reader["AnswerA"]);
            entity.AnswerB = NullHandler.GetString(reader["AnswerB"]);
            entity.AnswerC = NullHandler.GetString(reader["AnswerC"]);
            entity.AnswerD = NullHandler.GetString(reader["AnswerD"]);

            return entity;
        }

        /// <summary>
        /// Get exams for a particular question types
        /// </summary>
        /// <param name="examType"></param>
        /// <returns></returns>
        public IList<QuestionForExamType> GetQuestionsForExamType(int examType)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "QuestionForExamTypeDAO.GetQuestionsForExamType(int)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("ExamID", DbType.Int32, examType)};

                    return GetAllInternal("spQuestionForExamTypeGetForExam", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "QuestionForExamTypeDAO.GetQuestionsForExamType(int)");
                }
            }
        }

        protected override void EagerLoad(App.Models.Exams.QuestionForExamType entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
