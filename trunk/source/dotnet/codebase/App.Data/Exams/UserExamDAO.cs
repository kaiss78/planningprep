


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: UserExamDAO.cs
 * Purpose: DAO Class to get/set the data from tblUserExam table.
 * 
 * Author: AFS
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/08/2010 11:28:26		Initial Development
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

namespace App.Data.UserExams
{
    public interface IUserExamDAO : IDataAccess<App.Models.UserExams.UserExam>
    {
    }

    public class UserExamDAO : BaseDataAccess<App.Models.UserExams.UserExam>, IUserExamDAO
    {
        #region Constructor
        public UserExamDAO()
        {
        }

        public UserExamDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.UserExams.UserExam Map(IDataReader reader)
        {
            App.Models.UserExams.UserExam entity = EntityFactory.Create<App.Models.UserExams.UserExam>();

            entity.Id = NullHandler.GetInt32(reader["ExamSessionID"]);
            entity.ExamSessionID = NullHandler.GetInt(reader["ExamSessionID"]);
            entity.UserID = NullHandler.GetInt(reader["UserID"]);
            entity.ExamID = NullHandler.GetInt(reader["ExamID"]);
            entity.StartDate = NullHandler.GetDateTime(reader["StartDate"]);
            entity.EndDate = NullHandler.GetDateTime(reader["EndDate"]);
            entity.TotalTime = NullHandler.GetInt(reader["TotalTime"]);

            return entity;
        }

        protected override void EagerLoad(App.Models.UserExams.UserExam entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
