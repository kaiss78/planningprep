


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: QuestionsDAO.cs
 * Purpose: DAO Class to get/set the data from tblQuestions table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/08/2010 21:35:36		Initial Development
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
using App.Core.Extensions;
using App.Core.Factories;
using System.Security.Principal;
using System.Data.SqlClient;

namespace App.Data.Questions
{
    public interface IQuestionsDAO : IDataAccess<App.Models.Questions.Questions>
    {
        DateTime LastQuestionDate();
        void SaveQuestionOfTheWeekAnswer(int questionID, int userId, String answer);
    }

    public class QuestionsDAO : BaseDataAccess<App.Models.Questions.Questions>, IQuestionsDAO
    {
        #region Constructor
        public QuestionsDAO()
        {
        }

        public QuestionsDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Questions.Questions Map(IDataReader reader)
        {
            App.Models.Questions.Questions entity = EntityFactory.Create<App.Models.Questions.Questions>();

            entity.Id = NullHandler.GetInt32(reader["QuestionID"]);
            entity.QuestionID = NullHandler.GetInt(reader["QuestionID"]);
            entity.Question = NullHandler.GetString(reader["Question"]);
            entity.AnswerA = NullHandler.GetString(reader["AnswerA"]);
            entity.AnswerB = NullHandler.GetString(reader["AnswerB"]);
            entity.AnswerC = NullHandler.GetString(reader["AnswerC"]);
            entity.AnswerD = NullHandler.GetString(reader["AnswerD"]);
            entity.CorrectAnswer = NullHandler.GetString(reader["CorrectAnswer"]);
            entity.Explanation = NullHandler.GetString(reader["Explanation"]);
            entity.WrittenBy = NullHandler.GetString(reader["WrittenBy"]);
            entity.When = NullHandler.GetDateTime(reader["When"]);
            entity.HistoryTheoryLaw = NullHandler.GetBoolean(reader["HistoryTheoryLaw"]);
            entity.TrendsIssues = NullHandler.GetBoolean(reader["TrendsIssues"]);
            entity.PlanMaking = NullHandler.GetBoolean(reader["PlanMaking"]);
            entity.FunctionalTopics = NullHandler.GetBoolean(reader["FunctionalTopics"]);
            entity.PlanImplementation = NullHandler.GetBoolean(reader["PlanImplementation"]);
            entity.Ethics = NullHandler.GetBoolean(reader["Ethics"]);
            entity.ModifiedBy = NullHandler.GetString(reader["ModifiedBy"]);
            entity.ModifiedWhen = NullHandler.GetDateTime(reader["ModifiedWhen"]);
            entity.RandomOrder = NullHandler.GetInt(reader["RandomOrder"]);
            entity.Count = NullHandler.GetInt(reader["Count"]);
            entity.Rating = NullHandler.GetObject(reader["Rating"]);
            entity.RateCount = NullHandler.GetInt(reader["RateCount"]);
            entity.RateTotal = NullHandler.GetInt(reader["RateTotal"]);

            return entity;
        }

        
        /// <summary>
        /// Gets Last Question Update Date
        /// </summary>
        /// <returns></returns>
        public DateTime LastQuestionDate()
        {
            DateTime lastQuestionDate = DateTime.Now;
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "QuestionsDAO.LastQuestionDate()"))
            {
                try
                {                    
                    DbCommand cmd = Database.GetSqlStringCommand("SELECT * FROM qry_menu_lastquestion");
                    IDataReader reader = ExecuteReader(cmd);
                    if (reader.IsNotNull())
                    {
                        if (reader.Read())
                        {
                            lastQuestionDate = NullHandler.GetDateTime(reader["When"]);
                        }
                        reader.Close();
                    }                    
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "UserDAO.GetUserByEmail(string)");
                }
            }
            return lastQuestionDate;
        }
        /// <summary>
        /// Processes Question of the Week Answer
        /// </summary>
        /// <param name="questionID"></param>
        /// <param name="userId"></param>
        /// <param name="answer"></param>
        public void SaveQuestionOfTheWeekAnswer(int questionID, int userId, String answer)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "QuestionsDAO.SaveQuestionOfTheWeekAnswer(int, int, string)"))
            {
                try
                {
                    DbCommand cmd = Database.GetStoredProcCommand("spSaveQuestionOfTheWeekAnswer");
                    cmd.Parameters.Add(new SqlParameter("@QuestionID", questionID));
                    cmd.Parameters.Add(new SqlParameter("@UserID", userId));
                    cmd.Parameters.Add(new SqlParameter("@Answer", answer));
                    int result = ExecuteNonQuery(cmd);                    
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "UserDAO.SaveQuestionOfTheWeekAnswer(int, int, string)");
                }
            }
        }
        protected override void EagerLoad(App.Models.Questions.Questions entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
