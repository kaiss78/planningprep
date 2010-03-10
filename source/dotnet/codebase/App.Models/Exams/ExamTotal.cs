


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		ExamTotal
 * Purpose: ExamTotal entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/11/2010 1:06:25 AM		Initial Code
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
    public class ExamTotal : BaseEntity
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
        /// Gets or sets the CountOfQuestionID
        /// </summary>
        /// <value>The CountOfQuestionID.</value>
        public int CountOfQuestionID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the SumOfCorrect
        /// </summary>
        /// <value>The SumOfCorrect.</value>
        public int SumOfCorrect
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
