


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		UserExam
 * Purpose: UserExam entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * AFS	3/8/2010 11:05:32 AM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;

namespace App.Models.UserExams
{
    [Serializable]
    public class UserExam : BaseEntity
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ExamSessionID
        /// </summary>
        /// <value>The ExamSessionID.</value>
        public int ExamSessionID
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
        /// Gets or sets the ExamID
        /// </summary>
        /// <value>The ExamID.</value>
        public int ExamID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the StartDate
        /// </summary>
        /// <value>The StartDate.</value>
        public DateTime StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the EndDate
        /// </summary>
        /// <value>The EndDate.</value>
        public DateTime EndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the TotalTime
        /// </summary>
        /// <value>The TotalTime.</value>
        public int TotalTime
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
