


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: OPUS
 * Module: OPUS.Data
 * Name: ProductDAO.cs
 * Purpose: DAO Class to get/set the data from Product table.
 * 
 * Author: Jason Duffus
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * User					Date					Comments
 * [Developer Name]		03/01/2010 11:44:25		Initial Development
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
using App.Models.Products;
using Models.Products;

namespace App.Data.Products
{
    public class ProductDAO : BaseDataAccess<Models.Products.Product>, IProductDAO
    {
        #region Constructor
        public ProductDAO()
        {
        }

        public ProductDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override Models.Products.Product Map(IDataReader reader)
        {
            Models.Products.Product entity = EntityFactory.Create<Models.Products.Product>();

            entity.Id = NullHandler.GetLong(reader["Id"]);
            entity.ProductName = NullHandler.GetString(reader["ProductName"]);
            entity.Price = NullHandler.GetDecimal(reader["Price"]);
            entity.CategoryId = NullHandler.GetLong(reader["ProductCategoryId"]);
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

        protected override void EagerLoad(Product entity)
        {
            // Add eager loading functionality here
            using (IProductCategoryDAO dao = (IProductCategoryDAO)DAOFactory.Get<ProductCategory>())
            {
                entity.ProductCategory = dao.Get(entity.CategoryId);
            }
        }

        /// <summary>
        /// Saves the reference properties before.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void SaveReferencePropertiesBefore(Models.Products.Product entity)
        {
            // Add to save reference properties functionality here
        }

        /// <summary>
        /// Saves the reference properties after.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void SaveReferencePropertiesAfter(Models.Products.Product entity)
        {
            // Add to save reference properties functionality here
        }
        #endregion
    }
}
