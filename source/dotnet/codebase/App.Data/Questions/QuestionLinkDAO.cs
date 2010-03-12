


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: QuestionLinkDAO.cs
 * Purpose: DAO Class to get/set the data from QuestionLink table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/12/2010 09:41:55		Initial Development
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
using App.Models.Questions;

namespace App.Data.Questions
{
    public interface IQuestionLinkDAO : IDataAccess<App.Models.Questions.QuestionLink>
    {
        IList<QuestionLink> GetQuestionLinks(int QuestionID);
    }

    public class QuestionLinkDAO : BaseDataAccess<App.Models.Questions.QuestionLink>, IQuestionLinkDAO
    {
        #region Constructor
        public QuestionLinkDAO()
        {
        }

        public QuestionLinkDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Questions.QuestionLink Map(IDataReader reader)
        {
            App.Models.Questions.QuestionLink entity = EntityFactory.Create<App.Models.Questions.QuestionLink>();

            entity.Id = NullHandler.GetInt32(reader["QuestionID"]);
            entity.QuestionID = NullHandler.GetInt(reader["QuestionID"]);
            entity.LinkID = NullHandler.GetInt(reader["LinkID"]);
            entity.Link = NullHandler.GetString(reader["Link"]);
            entity.LinkTitle = NullHandler.GetString(reader["LinkTitle"]);
            entity.LinkDescription = NullHandler.GetString(reader["LinkDescription"]);
            entity.Count = NullHandler.GetInt(reader["Count"]);
            entity.Rating = NullHandler.GetObject(reader["Rating"]);
            entity.RateCount = NullHandler.GetInt(reader["RateCount"]);
            entity.RateTotal = NullHandler.GetInt(reader["RateTotal"]);

            return entity;
        }

        /// <summary>
        /// Get Question links
        /// </summary>
        /// <param name="QuestionID"></param>
        /// <returns></returns>
        public IList<QuestionLink> GetQuestionLinks(int QuestionID)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "QuestionLinkDAO.GetQuestionLinks(int)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("QuestionID", DbType.String, QuestionID)};

                    return GetAllInternal("spGetQuestionLinks", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "QuestionLinkDAO.GetQuestionLinks(int)");
                }
            }
        }

        protected override void EagerLoad(App.Models.Questions.QuestionLink entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
