#region History

/* --------------------------------------------------------------------------------
 * Client Name: NQF
 * Project Name: OPLM
 * Module: OPLM.Common
 * Name: Group.cs
 * Purpose: Group class for "Group"
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
using System.Data;
using OPUS.Models.Base;
using Pantheon.Core.DB;
using Pantheon.Core.Factories;

#endregion

namespace OPUS.Models.Users
{
    /// <summary>
    /// Group class for "Group"
    /// </summary>
    [Serializable]
    public class Role : TableLevelAuditEntity
    {
        public static Role CreateFromDataReader(IDataReader reader)
        {
            Role user = EntityFactory.Create<Role>();

            user.Id = NullHandler.GetLong(reader["Id"]);
            user.Name = NullHandler.GetString(reader["Name"]);

            return user;
        }

        #region Properties

        /// <summary>
        /// Gets or sets name of the role
        /// </summary>
        public string Name { get; set; }

        public string Description { get; set; }

        #endregion
    }
}