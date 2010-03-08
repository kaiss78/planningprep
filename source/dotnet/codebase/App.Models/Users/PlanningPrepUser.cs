#region History

/* --------------------------------------------------------------------------------
 * Client Name: NQF
 * Project Name: OPLM
 * Module: OPLM.Common
 * Name: User.cs
 * Purpose: User class for "User"
 *                   
 * Author: AFS
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    AFS  09/26/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */

#endregion

#region References

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using App.Models.Roles;
using App.Core.Base.Model;
using App.Core.DB;
using System.Data;
using App.Core.Factories;

#endregion

namespace App.Models.Users
{
    /// <summary>
    /// User class for "User"
    /// </summary>
    public class AppUser : BaseEntity
    {
        #region Instance creation

        /// <summary>
        /// Creates an user from DataReader
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        public static AppUser CreateBaseUserFromDataReader(IDataReader reader)
        {
            AppUser user = EntityFactory.Create<AppUser>();

            user.Id = NullHandler.GetInt32(reader["UserID"]);
            user.UserName = NullHandler.GetString(reader["UserName"]);
            user.FirstName = NullHandler.GetString(reader["FirstName"]);
            user.LastName = NullHandler.GetString(reader["LastName"]);
            user.Email = NullHandler.GetString(reader["Email"]);
            user.Title = NullHandler.GetString(reader["Title"]);
            user.IMISUserId = NullHandler.GetLong(reader["OPLMIMISUserID"]);
            
            return user;
        }

        /// <summary>
        /// Creates an user from DataReader
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        public static AppUser CreateFromDataReader(IDataReader reader)
        {
            AppUser user = EntityFactory.Create<AppUser>();

            user.Id = NullHandler.GetInt(reader["UserID"]);
            user.IMISUserId = NullHandler.GetLong(reader["OPLMIMISUserID"]);
           // user.IMISUserID = NullHandler.GetString(reader["IMISUserID"]);
            //user.Active = NullHandler.GetBoolean(reader["Active"]);
            user.Email = NullHandler.GetString(reader["Email"]);
            user.FirstName = NullHandler.GetString(reader["FirstName"]);
            user.LastName = NullHandler.GetString(reader["LastName"]);
            user.IMISMemberType = NullHandler.GetString(reader["MemberType"]);
            user.Title = NullHandler.GetString(reader["Title"]);
            user.UserName = NullHandler.GetString(reader["UserName"]);
          //  user.RoleName = NullHandler.GetString(reader["RoleName"]);
            user.Id = NullHandler.GetInt(reader["RoleID"]);

            Role role = new Role();
            IList<Role> roles = new List<Role>();
           // role.ID = user.RoleID;
           // role.Name = user.RoleName;
            roles.Add(role);

            user.UserRoles = roles;

            return user;
        }

        #endregion

        #region Properties

        public string UserName { get; set; }


        //[XmlIgnore]
        //public CContactUser IMISUser { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long IMISUserId { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string IMISMemberType { get; set; }

        /// <summary>
        /// Gets or sets the user groups.
        /// </summary>
        /// <value>The user groups.</value>
        [XmlIgnore]
        public IList<Role> UserRoles { get; set; }

        #region ********* DEV: MHR ************** IT#4

        public string Organization { get; set; }

        public string PhoneNo { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PrimaryCouncil { get; set; }

        #region ********* DEV: MRZ ************** IT#5

        public string ContactID { get; set; }

        #endregion

        #endregion

        #endregion

        #region ****************DEV: MH ************** Refactor
        /// <summary>
        /// Gets if the logged in user is admin
        /// </summary>
        public bool IsAdmin
        {
            get
            {                
                if (UserRoles != null && UserRoles.Count > 0)
                {
                    //if (this.UserRoles[0].ID == OPLMConstants.ConfigurationParams.OPLM_ADMIN_ROLE_ID)
                    //{
                        return true;
                    //}
                }
                return false;
            }
        }

        /// <summary>
        /// Gets if the logged in user is editor
        /// </summary>
        public bool IsEditor
        {
            get
            {
                if (UserRoles != null && UserRoles.Count > 0)
                {
                    //if (this.UserRoles[0].ID == OPLMConstants.ConfigurationParams.OPLM_EDITOR_ROLE_ID)
                    //{
                        return true;
                    //}
                }
                return false;                
            }
        }

        /// <summary>
        /// Gets if the logged in user is readonly
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                if (UserRoles != null && UserRoles.Count > 0)
                {
                    //if (this.UserRoles[0].ID == OPLMConstants.ConfigurationParams.OPLM_READONLY_ROLE_ID)
                    //{
                        return true;
                    //}
                }              
                return false;
            }
        }
        #endregion
    }
}