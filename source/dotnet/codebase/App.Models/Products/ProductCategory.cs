


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		ProductCategory
 * Purpose: ProductCategory entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * AFS	3/4/2010 1:29:53 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Models.Base;

namespace Models.Products
{
    [Serializable]
    public class ProductCategory : TableLevelAuditEntity
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ProductCategoryName
        /// </summary>
        /// <value>The ProductCategoryName.</value>
        public string CategoryName
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
