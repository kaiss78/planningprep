


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		ExamStatistic
 * Purpose: ExamStatistic entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/18/2010 12:22:24 AM		Initial Code
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
    public class ExamStatistic : BaseEntity
    {
        #region Fields
        #endregion

        #region Properties

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
        /// Gets or sets the Taken
        /// </summary>
        /// <value>The Taken.</value>
        public int Taken
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Correct
        /// </summary>
        /// <value>The Correct.</value>
        public int Correct
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the TotalTime
        /// </summary>
        /// <value>The TotalTime.</value>
        public long TotalTime
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
