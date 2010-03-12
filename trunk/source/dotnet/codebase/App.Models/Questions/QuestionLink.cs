


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		QuestionLinks
 * Purpose: QuestionLinks entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/12/2010 9:40:22 AM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;

namespace App.Models.Questions
{
    [Serializable]
    public class QuestionLink : BaseEntity
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the QuestionID
        /// </summary>
        /// <value>The QuestionID.</value>
        public int QuestionID
        {
            get;
            set;
        }

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
        public string Link
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
