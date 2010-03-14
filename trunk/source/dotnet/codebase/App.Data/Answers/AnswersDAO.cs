


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: AnswersDAO.cs
 * Purpose: DAO Class to get/set the data from tblAnswers table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/14/2010 16:04:45		Initial Development
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

namespace App.Data.Answers
{
    public interface IAnswersDAO : IDataAccess<App.Models.Answers.Answers>
    {
    }

    public class AnswersDAO : BaseDataAccess<App.Models.Answers.Answers>, IAnswersDAO
    {
        #region Constructor
        public AnswersDAO()
        {
        }

        public AnswersDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Answers.Answers Map(IDataReader reader)
        {
            App.Models.Answers.Answers entity = EntityFactory.Create<App.Models.Answers.Answers>();

            entity.Id = NullHandler.GetInt32(reader["ID"]);
            entity.ID = NullHandler.GetInt(reader["ID"]);
            entity.UserID = NullHandler.GetInt(reader["UserID"]);
            entity.QuestionID = NullHandler.GetInt(reader["QuestionID"]);
            entity.Answer = NullHandler.GetString(reader["Answer"]);
            entity.TimeStamp = NullHandler.GetDateTime(reader["TimeStamp"]);
            entity.CorrectAnswer = NullHandler.GetString(reader["CorrectAnswer"]);
            entity.Correct = NullHandler.GetInt(reader["Correct"]);
            entity.Time = NullHandler.GetInt(reader["Time"]);
            entity.ExamSessionID = NullHandler.GetInt(reader["ExamSessionID"]);

            return entity;
        }

        protected override void EagerLoad(App.Models.Answers.Answers entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
