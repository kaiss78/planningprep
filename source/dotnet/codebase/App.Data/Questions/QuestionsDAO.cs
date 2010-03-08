


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
using App.Core.Factories;
using System.Security.Principal;

namespace App.Data.Questions
{
    public interface IQuestionsDAO : IDataAccess<App.Models.Questions.Questions>
    {
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

        protected override void EagerLoad(App.Models.Questions.Questions entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
