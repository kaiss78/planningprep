


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Exam
 * Purpose: Exam entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/9/2010 9:22:18 PM		Initial Code
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
    public class Exam : BaseEntity
    {
        #region Fields
        #endregion

        #region Properties

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
        /// Gets or sets the Title
        /// </summary>
        /// <value>The Title.</value>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        /// <value>The CreatedBy.</value>
        public string CreatedBy
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
        /// Gets or sets the ActivationDate
        /// </summary>
        /// <value>The ActivationDate.</value>
        public DateTime ActivationDate
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
