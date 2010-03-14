


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Questions
 * Purpose: Questions entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/8/2010 9:36:19 PM		Initial Code
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
    public class Questions : BaseEntity
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
        /// Gets or sets the Explanation
        /// </summary>
        /// <value>The Explanation.</value>
        public string Explanation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the WrittenBy
        /// </summary>
        /// <value>The WrittenBy.</value>
        public string WrittenBy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the When
        /// </summary>
        /// <value>The When.</value>
        public DateTime When
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HistoryTheoryLaw
        /// </summary>
        /// <value>The HistoryTheoryLaw.</value>
        public bool HistoryTheoryLaw
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the TrendsIssues
        /// </summary>
        /// <value>The TrendsIssues.</value>
        public bool TrendsIssues
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the PlanMaking
        /// </summary>
        /// <value>The PlanMaking.</value>
        public bool PlanMaking
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the FunctionalTopics
        /// </summary>
        /// <value>The FunctionalTopics.</value>
        public bool FunctionalTopics
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the PlanImplementation
        /// </summary>
        /// <value>The PlanImplementation.</value>
        public bool PlanImplementation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Ethics
        /// </summary>
        /// <value>The Ethics.</value>
        public bool Ethics
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ModifiedBy
        /// </summary>
        /// <value>The ModifiedBy.</value>
        public string ModifiedBy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ModifiedWhen
        /// </summary>
        /// <value>The ModifiedWhen.</value>
        public DateTime ModifiedWhen
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the RandomOrder
        /// </summary>
        /// <value>The RandomOrder.</value>
        public int RandomOrder
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
        public float Rating
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
