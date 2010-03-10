


#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: App.Data
 * Name: PlanningPrepUserDAO.cs
 * Purpose: DAO Class to get/set the data from tblPlanningPrepUser table.
 * 
 * PlanningPrepUser: Shubho
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * Product					Date					Comments
 * [Developer Name]		03/08/2010 21:06:19		Initial Development
 * -------------------------------------------------------------------------------- 
 */
#endregion

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using App.Models.Enums;
using App.Core;
using App.Core.DB;
using App.Core.Exceptions;
using App.Core.Factories;
using System.Security.Principal;
using App.Models.Users;

namespace App.Data.Users
{
    public interface IUserDAO : IDataAccess<App.Models.Users.PlanningPrepUser>
    {
        PlanningPrepUser GetUserByUserNamePassword(string userName, string password);
        PlanningPrepUser GetUserByUserName(string userName);
        PlanningPrepUser GetUserByEmail(string email);
    }

    public class UserDAO : BaseDataAccess<App.Models.Users.PlanningPrepUser>, IUserDAO
    {
        #region Constructor
        public UserDAO()
        {
        }

        public UserDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        protected override App.Models.Users.PlanningPrepUser Map(IDataReader reader)
        {
            App.Models.Users.PlanningPrepUser entity = EntityFactory.Create<App.Models.Users.PlanningPrepUser>();

            entity.Id = NullHandler.GetInt32(reader["Author_ID"]);
            entity.Author_ID = NullHandler.GetInt(reader["Author_ID"]);
            entity.Username = NullHandler.GetString(reader["Username"]);
            entity.User_code = NullHandler.GetString(reader["User_code"]);
            entity.Password = NullHandler.GetString(reader["Password"]);
            entity.Author_email = NullHandler.GetString(reader["Author_email"]);
            entity.Show_email = NullHandler.GetBoolean(reader["Show_email"]);
            entity.Homepage = NullHandler.GetString(reader["Homepage"]);
            entity.Location = NullHandler.GetString(reader["Location"]);
            entity.Signature = NullHandler.GetString(reader["Signature"]);
            entity.No_of_posts = NullHandler.GetInt(reader["No_of_posts"]);
            entity.Join_date = NullHandler.GetDateTime(reader["Join_date"]);
            entity.Active = NullHandler.GetBoolean(reader["Active"]);
            entity.Status = NullHandler.GetInt(reader["Status"]);
            entity.Avatar = NullHandler.GetString(reader["Avatar"]);
            entity.Surname = NullHandler.GetString(reader["Surname"]);
            entity.FirstName = NullHandler.GetString(reader["FirstName"]);
            entity.LastName = NullHandler.GetString(reader["LastName"]);
            entity.Address = NullHandler.GetString(reader["Address"]);
            entity.City = NullHandler.GetString(reader["City"]);
            entity.State = NullHandler.GetString(reader["State"]);
            entity.ZIP = NullHandler.GetString(reader["ZIP"]);
            entity.HomePhone = NullHandler.GetString(reader["HomePhone"]);
            entity.WorkPhone = NullHandler.GetString(reader["WorkPhone"]);
            entity.Employer = NullHandler.GetString(reader["Employer"]);
            entity.Title = NullHandler.GetString(reader["Title"]);
            entity.HowHear = NullHandler.GetString(reader["HowHear"]);
            entity.LastLogin = NullHandler.GetDateTime(reader["LastLogin"]);
            entity.LoginNumber = NullHandler.GetInt(reader["LoginNumber"]);
            entity.Rights = NullHandler.GetString(reader["Rights"]);
            entity.Mode = NullHandler.GetString(reader["Mode"]);
            entity.YesTermsofAgreement = NullHandler.GetBoolean(reader["YesTermsofAgreement"]);
            entity.WhenTOA = NullHandler.GetDateTime(reader["WhenTOA"]);
            entity.Passed = NullHandler.GetString(reader["Passed"]);

            return entity;
        }

        /// <summary>
        /// Get User by UserName and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public PlanningPrepUser GetUserByUserNamePassword(string userName, string password)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "UserDAO.GetUserByUserNamePassword(string,string)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("userName", DbType.String, userName), new DbParameter("password", DbType.String, password) };

                    return GetInternal("spAuthorGetForUserNamePassword", parameters);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "UserDAO.GetUserByUserNamePassword(string,string)");
                }
            }
        }
        /// <summary>
        /// Gets User by Author Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public PlanningPrepUser GetUserByEmail(string email)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "UserDAO.GetUserByEmail(string)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("email", DbType.String, email)};

                    return GetInternal("spAuthorGetByEmail", parameters);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "UserDAO.GetUserByEmail(string)");
                }
            }
        }
        

        /// <summary>
        /// Get User by UserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public PlanningPrepUser GetUserByUserName(string userName)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "UserDAO.GetUserByUserName(string)"))
            {
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("userName", DbType.String, userName)};

                    return GetInternal("spAuthorGetForUserName", parameters);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "UserDAO.GetUserByUserName(string)");
                }
            }
        }

        protected override void EagerLoad(App.Models.Users.PlanningPrepUser entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}
