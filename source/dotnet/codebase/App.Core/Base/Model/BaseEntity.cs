#region History

/* --------------------------------------------------------------------------------
 * Client Name: NQF
 * Project Name: OPLM
 * Module: OPLM.Common
 * Name: BaseEntity.cs
 * Purpose: Base Entity class
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
using App.Core.DB;

#endregion

namespace App.Core.Base.Model
{
    /// <summary>
    /// Base class for Entity
    /// </summary>
    [Serializable]
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [ParameterExclusion]
        public long Id { get; set; }
        /// <summary>
        /// Gets a value indicating whether this instance is new.
        /// </summary>
        /// <value><c>true</c> if this instance is new; otherwise, <c>false</c>.</value>
        [ParameterExclusion]
        public bool IsNew { get { return (Id <= 0); } }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseEntity"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        //public bool Active { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseEntity"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        //public bool Deleted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseEntity"/> is locked.
        /// </summary>
        /// <value><c>true</c> if locked; otherwise, <c>false</c>.</value>
        //public bool Locked { get; set; }

        /// <summary>
        /// Gets or sets the datetime stamp.
        /// </summary>
        /// <value>The datetime stamp.</value>
        //public DateTime DatetimeStamp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is loading.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is loading; otherwise, <c>false</c>.
        /// </value>
        //[ParameterExclusion]
        //public bool IsLoading { get; set; }

        /// <summary>
        /// Cleans the before save.
        /// </summary>
        public virtual void CleanBeforeSave()
        {
            //if (IsNew)
            //{
            //    Active = true;
            //    Deleted = false;
            //    Locked = false;
            //}
        }
    }
}