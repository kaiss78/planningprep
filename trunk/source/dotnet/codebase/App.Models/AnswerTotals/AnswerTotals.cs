


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		AnswerTotal
 * Purpose: AnswerTotal entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/11/2010 1:02:39 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;

namespace App.Models.AnswerTotals
{
    [Serializable]
    public class AnswerTotal : BaseEntity
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
        /// Gets or sets the A
        /// </summary>
        /// <value>The A.</value>
        public int A
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the B
        /// </summary>
        /// <value>The B.</value>
        public int B
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the C
        /// </summary>
        /// <value>The C.</value>
        public int C
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the D
        /// </summary>
        /// <value>The D.</value>
        public int D
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Total
        /// </summary>
        /// <value>The Total.</value>
        public int Total
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
