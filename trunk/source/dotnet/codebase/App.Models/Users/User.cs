#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		User
 * Purpose: User entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Jason Duffus	1/10/2010 5:37:52 AM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using App.Models.Roles;
using App.Core.DB;
using App.Core.Base.Model;

namespace App.Models.Users
{
    [Serializable]
    public class User :BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the IMISUserId
        /// </summary>
        /// <value>The IMISUserId.</value>
        public string IMISUserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the IMISMemberType
        /// </summary>
        /// <value>The IMISMemberType.</value>
        public string IMISMemberType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        /// <value>The UserName.</value>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        /// <value>The Email.</value>
        public string Email
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
        /// Gets or sets the LastName
        /// </summary>
        /// <value>The LastName.</value>
        public string LastName
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
        /// Gets or sets the Organization
        /// </summary>
        /// <value>The Organization.</value>
        public string Organization
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
        /// Gets or sets the HomePhone
        /// </summary>
        /// <value>The HomePhone.</value>
        public string HomePhone
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
        /// Gets or sets the PrimaryCouncil
        /// </summary>
        /// <value>The PrimaryCouncil.</value>
        public string PrimaryCouncil
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ContactId
        /// </summary>
        /// <value>The ContactId.</value>
        public string ContactId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the RoleId
        /// </summary>
        /// <value>The RoleId.</value>
        public long RoleId
        {
            get;
            set;
        }
        #endregion

        #region Reference Properties
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        [ParameterExclusion]
        public List<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the activities.
        /// </summary>
        /// <value>The activities.</value>
        [ParameterExclusion]
        public List<UserActivity> Activities { get; set; }

        /// <summary>
        /// Gets if the logged in user is admin
        /// </summary>
        [ParameterExclusion]
        public bool IsAdmin
        {
            get
            {
                if (Roles != null)
                {
                    return Roles.Any(r => r.Id == RoleId && r.IsAdmin);
                }
                return false;
            }
        }

        /// <summary>
        /// Gets if the logged in user is editor
        /// </summary>
        [ParameterExclusion]
        public bool IsEditor
        {
            get
            {
                if (Roles != null)
                {
                    return Roles.Any(r => r.Id == RoleId && r.IsEditor);
                }
                return false;
            }
        }

        /// <summary>
        /// Gets if the logged in user is readonly
        /// </summary>
        [ParameterExclusion]
        public bool IsReadOnly
        {
            get
            {
                if (Roles != null)
                {
                    return Roles.Any(r => r.Id == RoleId && r.IsReadOnly);
                }
                return false;
            }
        }
        #endregion

        #region Methods
       
        #endregion

        #region Business Validations

        // TODO: Add methods here.
        #endregion
    }
}