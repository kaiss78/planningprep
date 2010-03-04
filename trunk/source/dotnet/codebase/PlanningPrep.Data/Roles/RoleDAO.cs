#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: PlanningPrep
 * Module: PlanningPrep.Data
 * Name: RoleDAO.cs
 * Purpose: DAO Class to get/set the data from Roles table.
 * 
 * Author: Jason Duffus
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * User					Date					Comments
 * [Developer Name]		01/11/2010 22:07:43		Initial Development
 * -------------------------------------------------------------------------------- 
 */
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using PlanningPrep.Models.Roles;
using PlanningPrep.Core;
using PlanningPrep.Core.DB;
using PlanningPrep.Core.Exceptions;
using PlanningPrep.Core.Factories;

namespace PlanningPrep.Data.Roles
{
    public class RoleDAO : BaseDataAccess<Role>, IRoleDAO
    {
        #region Constructor
        public RoleDAO()
        {
        }

        public RoleDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves the role for user.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <param name="userId">The user id.</param>
        public void SaveRoleForUser(long roleId, long userId)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "Unknown User", "RoleDAO.SaveRoleForUser(Role,DbTransaction)"))
            {
                try
                {
                    Check.Require(roleId > 0, "Can't save without a valid roleId.");
                    Check.Require(userId > 0, "Can't save without a valid userId.");

                    // First Delete User/Role relation row
                    DbParameter[] parameters = new[]
                                                     {
                                                         new DbParameter("RoleId", DbType.Int64, roleId),
                                                         new DbParameter("UserId", DbType.Int64, userId)
                                                     };
                    
                    DeleteInternal("spUserRoleDelete", parameters);

                    // Second Save User/Role relation row
                    parameters = new[]
                                     {
                                         new DbParameter("RoleId", DbType.Int64, roleId),
                                         new DbParameter("Name", DbType.Int64, userId)
                                     };

                    SaveInternal("spUserRoleSet", parameters);
                }
                catch (Exception ex)
                {
                    Exception excToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(excToUse.Message, excToUse, "RoleDAO.SaveRoleForUser(Role,DbTransaction)");
                }
            }
        }

        /// <summary>
        /// Saves the role for user.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <param name="userId">The user id.</param>
        public void SaveRolesForUser(List<Role> roles, long userId)
        {
            roles.ForEach(r => SaveRoleForUser(r.Id, userId));
        }

        /// <summary>
        /// Deletes the user from role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public bool DeleteUserFromRole(long roleId, long userId)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "Unknown User", "RoleDAO.DeleteUserFromRole(long,long,DbTransaction)"))
            {
                try
                {
                    Check.Require(roleId > 0, "Can't delete user from role without a valid roleId.");
                    Check.Require(userId > 0, "Can't delete user from role without a valid userId.");

                    DbParameter[] parameters = new[]
                                                     {
                                                         new DbParameter("RoleId", DbType.Int64, roleId),
                                                         new DbParameter("UserId", DbType.Int64, userId)
                                                     };

                    return DeleteInternal("spUserRoleDelete", parameters);
                }
                catch (Exception ex)
                {
                    Exception excToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(excToUse.Message, excToUse, "RoleDAO.DeleteUserFromRole(long,long,DbTransaction)");
                }
            }
        }

        /// <summary>
        /// Gets for user.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public List<Role> GetAllForUser(long id, bool eagerLoad)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", "RoleDAO.GetForUser(long,bool)"))
            {
                try
                {
                    Check.Require(id > 0, "Can't get an entity with a invalid id.");

                    DbParameter[] parameters = new[] { new DbParameter("Id", DbType.Int64, id) };

                    return GetAllInternal("spRoleGetAllForUser", parameters, eagerLoad);
                }
                catch (Exception ex)
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(exToUse.Message, exToUse, "RoleDAO.GetForUser(long,bool)");
                }
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Maps and sets the Entity Model from the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        protected override Role Map(IDataReader reader)
        {
            Role entity = EntityFactory.Create<Role>();

            entity.Id = NullHandler.GetLong(reader["Id"]);
            entity.Name = NullHandler.GetString(reader["Name"]);
            entity.Description = NullHandler.GetString(reader["Description"]);
            entity.IsAdmin = NullHandler.GetBoolean(reader["IsAdmin"]);
            entity.IsEditor = NullHandler.GetBoolean(reader["IsEditor"]);
            entity.IsReadOnly = NullHandler.GetBoolean(reader["IsReadOnly"]);
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
        /// <summary>
        /// Eager load entity model reference properties.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void EagerLoad(Role entity)
        {
            // Add eager loading functionality here
        }
        #endregion
    }
}