


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: FaqCategoryDAO.cs
 * Purpose: DAO Class to get/set the data from FaqCategory table.
 * 
 * Author: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/18/2010 19:55:31		Initial Development
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
    public interface IFaqCategoryDAO : IDataAccess<App.Models.FAQ.FaqCategory>
    {
    }

    public class FaqCategoryDAO : BaseDataAccess<App.Models.FAQ.FaqCategory>, IFaqCategoryDAO
    {
        #region Constructor
        public FaqCategoryDAO()
        {
        }

        public FaqCategoryDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.FAQ.FaqCategory Map(IDataReader reader)
        {
            App.Models.FAQ.FaqCategory entity = EntityFactory.Create<App.Models.FAQ.FaqCategory>();

            entity.Id = NullHandler.GetInt32(reader["FaqCatID"]);
            entity.FaqCatID = NullHandler.GetInt(reader["FaqCatID"]);
            entity.Category = NullHandler.GetString(reader["Category"]);
            entity.CatOrder = NullHandler.GetInt(reader["CatOrder"]);
            entity.TimeStamp = NullHandler.GetDateTime(reader["TimeStamp"]);
            entity.EnteredBy = NullHandler.GetString(reader["EnteredBy"]);

            return entity;
        }

        protected override void EagerLoad(App.Models.FAQ.FaqCategory entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
