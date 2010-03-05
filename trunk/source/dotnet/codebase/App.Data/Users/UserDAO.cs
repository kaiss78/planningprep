#region usings

using System;
using System.Data;
using App.Data.Roles;
using App.Models.Roles;
using App.Models.Users;
using App.Core.DB;
using App.Core.Extensions;
using App.Core.Factories;

#endregion

namespace App.Data.Users
{
    public class UserDAO : BaseDataAccess<User>, IUserDAO
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
        protected override User Map(IDataReader reader)
        {
            User entity = EntityFactory.Create<User>();

            entity.Id = NullHandler.GetLong(reader["Id"]);
            entity.IMISUserId = NullHandler.GetString(reader["IMISUserId"]);
            entity.IMISMemberType = NullHandler.GetString(reader["IMISMemberType"]);
            entity.UserName = NullHandler.GetString(reader["UserName"]);
            entity.Email = NullHandler.GetString(reader["Email"]);
            entity.FirstName = NullHandler.GetString(reader["FirstName"]);
            entity.LastName = NullHandler.GetString(reader["LastName"]);
            entity.Title = NullHandler.GetString(reader["Title"]);
            entity.Organization = NullHandler.GetString(reader["Organization"]);
            entity.WorkPhone = NullHandler.GetString(reader["WorkPhone"]);
            entity.HomePhone = NullHandler.GetString(reader["HomePhone"]);
            entity.City = NullHandler.GetString(reader["City"]);
            entity.State = NullHandler.GetString(reader["State"]);
            entity.PrimaryCouncil = NullHandler.GetString(reader["PrimaryCouncil"]);
            entity.ContactId = NullHandler.GetString(reader["ContactId"]);
            entity.RoleId = NullHandler.GetLong(reader["RoleId"]);
            entity.Active = NullHandler.GetBoolean(reader["Active"]);
            entity.Deleted = NullHandler.GetBoolean(reader["Deleted"]);
            entity.Locked = NullHandler.GetBoolean(reader["Locked"]);
            entity.CreatedBy = NullHandler.GetString(reader["CreatedBy"]);
            entity.CreatedByDateTime = NullHandler.GetDateTime(reader["CreatedByDateTime"]);
            entity.LastModifiedBy = NullHandler.GetString(reader["LastModifiedBy"]);
            entity.LastModifiedByDateTime = NullHandler.GetDateTime(reader["LastModifiedByDateTime"]);
            entity.DatetimeStamp = NullHandler.GetDateTime(reader["DatetimeStamp"]);

            return entity;
        }

        protected override void EagerLoad(User entity)
        {
            // Add eager loading functionality here
            using(IRoleDAO dao = (IRoleDAO) DAOFactory.Get<Role>())
            {
                entity.Roles = dao.GetAllForUser(entity.Id, true);
            }
        }

        /// <summary>
        /// Saves the reference properties before.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void SaveReferencePropertiesBefore(User entity)
        {
        }

        /// <summary>
        /// Saves the reference properties after.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void SaveReferencePropertiesAfter(User entity)
        {
            if(entity.Activities.IsNotNull())
            {
                using(IUserActivityDAO dao = (IUserActivityDAO) DAOFactory.Get<UserActivity>())
                {
                    dao.SaveAll(entity.Activities);
                }
            }
        }

        #endregion

        /// <summary>
        /// Determines whether [is user assigned to project] [the specified user id].
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="projectId">The project id.</param>
        /// <returns>
        /// 	<c>true</c> if [is user assigned to project] [the specified user id]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsUserAssignedToProject(long userId, long projectId)
        {
            return true;
        }

        /// <summary>
        /// Gets the name of the by user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public User GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}