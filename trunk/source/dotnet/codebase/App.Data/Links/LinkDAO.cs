


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: LinksDAO.cs
 * Purpose: DAO Class to get/set the data from tblLinks table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/11/2010 15:48:18		Initial Development
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

namespace App.Data.Links
{
    public interface ILinkDAO : IDataAccess<App.Models.Links.Link>
    {
        IList<App.Models.Links.Link> GetLinksForQuestion(int questionID);
    }

    public class LinkDAO : BaseDataAccess<App.Models.Links.Link>, ILinkDAO
    {
        #region Constructor
        public LinkDAO()
        {
        }

        public LinkDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Links.Link Map(IDataReader reader)
        {
            App.Models.Links.Link entity = EntityFactory.Create<App.Models.Links.Link>();

            entity.Id = NullHandler.GetInt32(reader["LinkID"]);
            entity.LinkID = NullHandler.GetInt(reader["LinkID"]);
            entity.LinkOriginal = NullHandler.GetString(reader["Link"]);
            entity.LinkTitle = NullHandler.GetString(reader["LinkTitle"]);
            entity.LinkDescription = NullHandler.GetString(reader["LinkDescription"]);
            entity.Count = NullHandler.GetInt(reader["Count"]);
            entity.Rating = NullHandler.GetObject(reader["Rating"]);
            entity.RateCount = NullHandler.GetInt(reader["RateCount"]);
            entity.RateTotal = NullHandler.GetInt(reader["RateTotal"]);
            entity.SubmittedBy = NullHandler.GetInt(reader["SubmittedBy"]);
            entity.TimeStamp = NullHandler.GetDateTime(reader["TimeStamp"]);

            return entity;
        }

        /// <summary>
        /// Gets Links for a Question by Question ID
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        public IList<App.Models.Links.Link> GetLinksForQuestion(int questionID)
        {
            //IList<App.Models.Links.Link> links = new List<App.Models.Links.Link>();
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "LinkDAO.GetLinksForQuestion(int)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("QuestionID", DbType.Int32, questionID) };

                    return GetAllInternal("spGetLinksForQuestion", parameters, false);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "UserDAO.GetUserByEmail(string)");
                }
            }
        }

        protected override void EagerLoad(App.Models.Links.Link entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
