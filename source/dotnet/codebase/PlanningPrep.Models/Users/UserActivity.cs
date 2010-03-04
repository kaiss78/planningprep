#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		UserActivitie
 * Purpose: UserActivitie entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Jason Duffus	1/10/2010 4:52:52 AM		Initial Code
 * =============================================
 */
#endregion

using System;
using PlanningPrep.Models.Enums;
using PlanningPrep.Core.Base.Model;

namespace PlanningPrep.Models.Users
{
    [Serializable]
    public class UserActivity : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        /// <value>The UserId.</value>
        public long UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ActivityType
        /// </summary>
        /// <value>The ActivityType.</value>
        public ActivityType ActivityType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ActivityTime
        /// </summary>
        /// <value>The ActivityTime.</value>
        public DateTime ActivityTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the IPAddress
        /// </summary>
        /// <value>The IPAddress.</value>
        public string IPAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the RequestedURL
        /// </summary>
        /// <value>The RequestedURL.</value>
        public string RequestedUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the SessionId
        /// </summary>
        /// <value>The SessionId.</value>
        public string SessionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the RefUrl
        /// </summary>
        /// <value>The RefUrl.</value>
        public string RefUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Browser
        /// </summary>
        /// <value>The Browser.</value>
        public string Browser
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ShortMessage
        /// </summary>
        /// <value>The ShortMessage.</value>
        public string ShortMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the LongMessage
        /// </summary>
        /// <value>The LongMessage.</value>
        public string LongMessage
        {
            get;
            set;
        }
        #endregion

        #region Reference Properties
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public User User { get; set; }
        #endregion

        #region Methods

        // TODO: Add methods here.
        #endregion

        #region Business Validations

        // TODO: Add methods here.
        #endregion
    }
}