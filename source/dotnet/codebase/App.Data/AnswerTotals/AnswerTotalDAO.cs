


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: AnswerTotalDAO.cs
 * Purpose: DAO Class to get/set the data from tbl_AnswerTotal table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/11/2010 13:00:29		Initial Development
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

namespace App.Data.AnswerTotals
{
    public interface IAnswerTotalDAO : IDataAccess<App.Models.AnswerTotals.AnswerTotal>
    {
    }

    public class AnswerTotalDAO : BaseDataAccess<App.Models.AnswerTotals.AnswerTotal>, IAnswerTotalDAO
    {
        #region Constructor
        public AnswerTotalDAO()
        {
        }

        public AnswerTotalDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.AnswerTotals.AnswerTotal Map(IDataReader reader)
        {
            App.Models.AnswerTotals.AnswerTotal entity = EntityFactory.Create<App.Models.AnswerTotals.AnswerTotal>();

            entity.Id = NullHandler.GetInt32(reader["QuestionID"]);
            entity.QuestionID = NullHandler.GetInt(reader["QuestionID"]);
            entity.A = NullHandler.GetInt(reader["A"]);
            entity.B = NullHandler.GetInt(reader["B"]);
            entity.C = NullHandler.GetInt(reader["C"]);
            entity.D = NullHandler.GetInt(reader["D"]);
            entity.Total = NullHandler.GetInt(reader["Total"]);

            return entity;
        }

        protected override void EagerLoad(App.Models.AnswerTotals.AnswerTotal entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
