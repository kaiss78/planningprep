


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		ResultDetails
 * Purpose: ResultDetails entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/12/2010 12:44:59 AM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;

namespace App.Models.Exams
{
    [Serializable]
    public class ResultDetails : BaseEntity
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
        /// Gets or sets the SerialNo
        /// </summary>
        /// <value>The SerialNo.</value>
        public int SerialNo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Result
        /// </summary>
        /// <value>The Result.</value>
        public string Result
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
        /// Gets or sets the CorrectAnswer
        /// </summary>
        /// <value>The CorrectAnswer.</value>
        public string CorrectAnswer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the YourAnswer
        /// </summary>
        /// <value>The YourAnswer.</value>
        public string YourAnswer
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
