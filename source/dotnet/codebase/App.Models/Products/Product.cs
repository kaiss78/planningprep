


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Product
 * Purpose: Product entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * AFS	3/1/2010 11:21:52 AM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Models.Base;
using Models.Products;

namespace App.Models.Products
{
    [Serializable]
    public class Product : TableLevelAuditEntity
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        /// <value>The ProductName.</value>
        public string ProductName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        /// <value>The Price.</value>
        public decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the CategoryId
        /// </summary>
        /// <value>The CategoryId.</value>
        public long CategoryId
        {
            get;
            set;
        }

        public ProductCategory ProductCategory
        {
            get;
            set;
        }
        #endregion

        #region Reference Properties
        // TODO: Add reference properties here.
        #endregion

        #region Methods
        // TODO: Add methods here.
        #endregion

        #region Override Methods
        // TODO: Add override methods here.
        #endregion
    }
}
