


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: ExamDAO.cs
 * Purpose: DAO Class to get/set the data from tblExam table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/09/2010 21:22:59		Initial Development
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
    public interface IExamDAO : IDataAccess<App.Models.Exams.Exam>
    {
    }

    public class ExamDAO : BaseDataAccess<App.Models.Exams.Exam>, IExamDAO
    {
        #region Constructor
        public ExamDAO()
        {
        }

        public ExamDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Exams.Exam Map(IDataReader reader)
        {
            App.Models.Exams.Exam entity = EntityFactory.Create<App.Models.Exams.Exam>();

            entity.Id = NullHandler.GetInt32(reader["ExamID"]);
            entity.ExamID = NullHandler.GetInt(reader["ExamID"]);
            entity.Title = NullHandler.GetString(reader["Title"]);
            entity.TimeStamp = NullHandler.GetDateTime(reader["TimeStamp"]);
            entity.CreatedBy = NullHandler.GetString(reader["CreatedBy"]);
            entity.ActivationDate = NullHandler.GetDateTime(reader["ActivationDate"]);

            return entity;
        }

        protected override void EagerLoad(App.Models.Exams.Exam entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
