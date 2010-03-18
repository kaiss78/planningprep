


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		FaqCategory
 * Purpose: FaqCategory entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/18/2010 7:57:00 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;

namespace App.Models.FAQ
{
    [Serializable]
    public class FaqCategory : BaseEntity
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the FaqCatID
        /// </summary>
        /// <value>The FaqCatID.</value>
        public int FaqCatID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Category
        /// </summary>
        /// <value>The Category.</value>
        public string Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the CatOrder
        /// </summary>
        /// <value>The CatOrder.</value>
        public int CatOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the TimeStamp
        /// </summary>
        /// <value>The TimeStamp.</value>
        public DateTime TimeStamp
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the EnteredBy
        /// </summary>
        /// <value>The EnteredBy.</value>
        public string EnteredBy
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
