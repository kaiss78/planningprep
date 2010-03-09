


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		ExamsSaved
 * Purpose: ExamsSaved entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/9/2010 11:50:09 PM		Initial Code
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
    public class ExamSaved : BaseEntity
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        /// <value>The ID.</value>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the UserID
        /// </summary>
        /// <value>The UserID.</value>
        public int UserID
        {
            get;
            set;
        }

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
        /// Gets or sets the Answer
        /// </summary>
        /// <value>The Answer.</value>
        public string Answer
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
        /// Gets or sets the Time
        /// </summary>
        /// <value>The Time.</value>
        public int Time
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ExamSessionID
        /// </summary>
        /// <value>The ExamSessionID.</value>
        public int ExamSessionID
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
