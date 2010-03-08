


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		QuestionForExamType
 * Purpose: QuestionForExamType entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/8/2010 10:59:59 PM		Initial Code
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
    public class QuestionForExamType : BaseEntity
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
        /// Gets or sets the ExamID
        /// </summary>
        /// <value>The ExamID.</value>
        public int ExamID
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
        /// Gets or sets the Question
        /// </summary>
        /// <value>The Question.</value>
        public string Question
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the AnswerA
        /// </summary>
        /// <value>The AnswerA.</value>
        public string AnswerA
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the AnswerB
        /// </summary>
        /// <value>The AnswerB.</value>
        public string AnswerB
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the AnswerC
        /// </summary>
        /// <value>The AnswerC.</value>
        public string AnswerC
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the AnswerD
        /// </summary>
        /// <value>The AnswerD.</value>
        public string AnswerD
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
