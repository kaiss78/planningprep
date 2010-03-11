


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Links
 * Purpose: Links entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/11/2010 3:50:28 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;

namespace App.Models.Links
{
    [Serializable]
    public class Link : BaseEntity
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the LinkID
        /// </summary>
        /// <value>The LinkID.</value>
        public int LinkID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Link
        /// </summary>
        /// <value>The Link.</value>
        public string LinkOriginal
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the LinkTitle
        /// </summary>
        /// <value>The LinkTitle.</value>
        public string LinkTitle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the LinkDescription
        /// </summary>
        /// <value>The LinkDescription.</value>
        public string LinkDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Count
        /// </summary>
        /// <value>The Count.</value>
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Rating
        /// </summary>
        /// <value>The Rating.</value>
        public object Rating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the RateCount
        /// </summary>
        /// <value>The RateCount.</value>
        public int RateCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the RateTotal
        /// </summary>
        /// <value>The RateTotal.</value>
        public int RateTotal
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the SubmittedBy
        /// </summary>
        /// <value>The SubmittedBy.</value>
        public int SubmittedBy
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
