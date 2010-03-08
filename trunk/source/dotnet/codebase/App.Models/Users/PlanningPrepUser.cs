


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Author
 * Purpose: Author entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/8/2010 9:09:57 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;

namespace App.Models.Users
{
    [Serializable]
    public class PlanningPrepUser : BaseEntity
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Author_ID
        /// </summary>
        /// <value>The Author_ID.</value>
        public int Author_ID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Username
        /// </summary>
        /// <value>The Username.</value>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the User_code
        /// </summary>
        /// <value>The User_code.</value>
        public string User_code
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        /// <value>The Password.</value>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Author_email
        /// </summary>
        /// <value>The Author_email.</value>
        public string Author_email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Show_email
        /// </summary>
        /// <value>The Show_email.</value>
        public bool Show_email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Homepage
        /// </summary>
        /// <value>The Homepage.</value>
        public string Homepage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Location
        /// </summary>
        /// <value>The Location.</value>
        public string Location
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Signature
        /// </summary>
        /// <value>The Signature.</value>
        public string Signature
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the No_of_posts
        /// </summary>
        /// <value>The No_of_posts.</value>
        public int No_of_posts
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Join_date
        /// </summary>
        /// <value>The Join_date.</value>
        public DateTime Join_date
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        /// <value>The Status.</value>
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Avatar
        /// </summary>
        /// <value>The Avatar.</value>
        public string Avatar
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Surname
        /// </summary>
        /// <value>The Surname.</value>
        public string Surname
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        /// <value>The FirstName.</value>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Active info
        /// </summary>
        /// <value>The Actove.</value>
        public bool Active
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        /// <value>The LastName.</value>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        /// <value>The Address.</value>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        /// <value>The City.</value>
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the State
        /// </summary>
        /// <value>The State.</value>
        public string State
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ZIP
        /// </summary>
        /// <value>The ZIP.</value>
        public string ZIP
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HomePhone
        /// </summary>
        /// <value>The HomePhone.</value>
        public string HomePhone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the WorkPhone
        /// </summary>
        /// <value>The WorkPhone.</value>
        public string WorkPhone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Employer
        /// </summary>
        /// <value>The Employer.</value>
        public string Employer
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
        /// Gets or sets the HowHear
        /// </summary>
        /// <value>The HowHear.</value>
        public string HowHear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the LastLogin
        /// </summary>
        /// <value>The LastLogin.</value>
        public DateTime LastLogin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the LoginNumber
        /// </summary>
        /// <value>The LoginNumber.</value>
        public int LoginNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Rights
        /// </summary>
        /// <value>The Rights.</value>
        public string Rights
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Mode
        /// </summary>
        /// <value>The Mode.</value>
        public string Mode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the YesTermsofAgreement
        /// </summary>
        /// <value>The YesTermsofAgreement.</value>
        public bool YesTermsofAgreement
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the WhenTOA
        /// </summary>
        /// <value>The WhenTOA.</value>
        public DateTime WhenTOA
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Passed
        /// </summary>
        /// <value>The Passed.</value>
        public string Passed
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
