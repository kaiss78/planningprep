


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: FaqDAO.cs
 * Purpose: DAO Class to get/set the data from Faq table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/18/2010 20:08:51		Initial Development
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

namespace App.Data.FAQ
{
    public interface IFaqDAO : IDataAccess<App.Models.FAQ.Faq>
    {
        IList<App.Models.FAQ.Faq> GetAllFaqSortByCategory();
    }

    public class FaqDAO : BaseDataAccess<App.Models.FAQ.Faq>, IFaqDAO
    {
        #region Constructor
        public FaqDAO()
        {
        }

        public FaqDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.FAQ.Faq Map(IDataReader reader)
        {
            App.Models.FAQ.Faq entity = EntityFactory.Create<App.Models.FAQ.Faq>();

            entity.Id = NullHandler.GetInt32(reader["FaqID"]);
            entity.FaqID = NullHandler.GetInt(reader["FaqID"]);
            entity.Question = NullHandler.GetString(reader["Question"]);
            entity.Answer = NullHandler.GetString(reader["Answer"]);
            entity.FaqCatID = NullHandler.GetInt(reader["FaqCatID"]);
            entity.TimeStamp = NullHandler.GetDateTime(reader["TimeStamp"]);
            entity.EnteredBy = NullHandler.GetString(reader["EnteredBy"]);

            return entity;
        }
        /// <summary>
        /// Gets All FAQ Questions Sorted by Category Name
        /// </summary>
        /// <returns></returns>
        public IList<App.Models.FAQ.Faq> GetAllFaqSortByCategory()
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "FaqDAO.GetAllFaqSortByCategory()"))
            {
                try
                {                    
                    return GetAllInternal("spFaqGetAllSorted", false);                    
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "FaqDAO.GetAllFaqSortByCategory()");
                }
            }
        }
        
        protected override void EagerLoad(App.Models.FAQ.Faq entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
