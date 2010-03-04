using System;
using PlanningPrep.Core.Base.Model;

namespace PlanningPrep.Models.Base
{
    [Serializable]
    public abstract class TableLevelAuditEntity : BaseEntity
    {
        
        // General table level audit
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created by date time.
        /// </summary>
        /// <value>The created by date time.</value>
        public DateTime CreatedByDateTime { get; set; }
        /// <summary>
        /// Gets or sets the last modified by.
        /// </summary>
        /// <value>The last modified by.</value>
        public string LastModifiedBy { get; set; }
        /// <summary>
        /// Gets or sets the last modified by date time.
        /// </summary>
        /// <value>The last modified by date time.</value>
        public DateTime LastModifiedByDateTime { get; set; }

        /// <summary>
        /// Sets the table level audit info.
        /// </summary>
        /// <param name="currentUser">The current user.</param>
        public void SetTableLevelAuditInfo(string currentUser)
        {
            DateTime auditDateTime = DateTime.Now;

            if (string.IsNullOrEmpty(currentUser))
            {
                currentUser = "System User";
            }

            if (IsNew)
            {
                CreatedBy = currentUser;
                CreatedByDateTime = auditDateTime;
            }
            LastModifiedBy = currentUser;
            LastModifiedByDateTime = auditDateTime;

            DatetimeStamp = auditDateTime;
        }
    }
}
