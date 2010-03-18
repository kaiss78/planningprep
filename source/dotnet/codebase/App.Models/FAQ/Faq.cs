


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Faq
 * Purpose: Faq entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/18/2010 8:09:37 PM		Initial Code
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
    public class Faq : BaseEntity
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the FaqID
        /// </summary>
        /// <value>The FaqID.</value>
        public int FaqID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Question
        /// </summary>
        /// <value>The Question.</value>
        public string Question
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Answer
        /// </summary>
        /// <value>The Answer.</value>
        public string Answer
        {
            get;
            set;
        }

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
