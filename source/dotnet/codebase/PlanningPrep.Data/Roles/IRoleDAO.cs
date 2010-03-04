using System.Collections.Generic;

namespace PlanningPrep.Data.Roles
{
    public interface IRoleDAO : IDataAccess<Models.Roles.Role>
    {
        /// <summary>
        /// Gets for user.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        List<Models.Roles.Role> GetAllForUser(long id, bool eagerLoad);
        /// <summary>
        /// Saves the role for user.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <param name="userId">The user id.</param>
        void SaveRoleForUser(long roleId, long userId);
        /// <summary>
        /// Saves the role for user.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <param name="userId">The user id.</param>
        void SaveRolesForUser(List<Models.Roles.Role> roles, long userId);
        /// <summary>
        /// Deletes the user from role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        bool DeleteUserFromRole(long roleId, long userId);
    }
}