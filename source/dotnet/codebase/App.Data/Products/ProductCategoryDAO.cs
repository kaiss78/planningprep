


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: App
 * Module: App.Data
 * Name: ProductCategoryDAO.cs
 * Purpose: DAO Class to get/set the data from ProductCategory table.
 * 
 * Author: AFS
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/04/2010 13:31:47		Initial Development
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
using Models.Products;

namespace App.Data.Products
{
    

    public class ProductCategoryDAO : BaseDataAccess<ProductCategory>, IProductCategoryDAO
    {
        #region Constructor
        public ProductCategoryDAO()
        {
        }

        public ProductCategoryDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override ProductCategory Map(IDataReader reader)
        {
            ProductCategory entity = EntityFactory.Create<ProductCategory>();

            entity.Id = NullHandler.GetLong(reader["Id"]);
            entity.CategoryName = NullHandler.GetString(reader["CategoryName"]);
            entity.Active = NullHandler.GetBoolean(reader["Active"]);
            entity.Deleted = NullHandler.GetBoolean(reader["Deleted"]);
            entity.Locked = NullHandler.GetBoolean(reader["Locked"]);
            entity.CreatedBy = NullHandler.GetString(reader["CreatedBy"]);
            entity.CreatedByDateTime = NullHandler.GetDateTime(reader["CreatedByDateTime"]);
            entity.LastModifiedBy = NullHandler.GetString(reader["LastModifiedBy"]);
            entity.LastModifiedByDateTime = NullHandler.GetDateTime(reader["LastModifiedByDateTime"]);
            entity.DatetimeStamp = NullHandler.GetDateTime(reader["DatetimeStamp"]);

            return entity;
        }

        protected override void EagerLoad(ProductCategory entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
