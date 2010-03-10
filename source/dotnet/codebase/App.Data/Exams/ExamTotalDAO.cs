


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: ExamTotalDAO.cs
 * Purpose: DAO Class to get/set the data from tblExamTotal table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/11/2010 01:07:43		Initial Development
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
    public interface IExamTotalDAO : IDataAccess<App.Models.Exams.ExamTotal>
    {
        ExamTotal GetExamTotal(int ExamSessionID);
    }

    public class ExamTotalDAO : BaseDataAccess<App.Models.Exams.ExamTotal>, IExamTotalDAO
    {
        #region Constructor
        public ExamTotalDAO()
        {
        }

        public ExamTotalDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Exams.ExamTotal Map(IDataReader reader)
        {
            App.Models.Exams.ExamTotal entity = EntityFactory.Create<App.Models.Exams.ExamTotal>();

            entity.Id = NullHandler.GetInt32(reader["ExamSessionID"]);
            entity.ExamSessionID = NullHandler.GetInt(reader["ExamSessionID"]);
            entity.CountOfQuestionID = NullHandler.GetInt(reader["CountOfQuestionID"]);
            entity.SumOfCorrect = NullHandler.GetInt(reader["SumOfCorrect"]);

            return entity;
        }

        /// <summary>
        /// Get Exam result an exam
        /// </summary>
        /// <param name="ExamSessionID"></param>
        /// <returns></returns>
        public ExamTotal GetExamTotal(int ExamSessionID)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "GetExamTotal.GetExamTotal(int)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("ExamSessionID", DbType.Int32, ExamSessionID) };

                    return GetInternal("spExamTotalGetForUser", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "GetExamTotal.GetExamTotal(int)");
                }
            }
        }


        protected override void EagerLoad(App.Models.Exams.ExamTotal entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
