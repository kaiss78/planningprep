#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Role
 * Purpose: Role entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Jason Duffus	1/10/2010 5:48:20 AM		Initial Code
 * =============================================
 */
#endregion

using System;
using PlanningPrep.Models.Base;

namespace PlanningPrep.Models.Roles
{
    [Serializable]
    public class Role : TableLevelAuditEntity
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        /// <value>The Name.</value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        /// <value>The Description.</value>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the IsAdmin
        /// </summary>
        /// <value>The IsAdmin.</value>
        public bool IsAdmin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the IsEditor
        /// </summary>
        /// <value>The IsEditor.</value>
        public bool IsEditor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the IsReadOnly
        /// </summary>
        /// <value>The IsReadOnly.</value>
        public bool IsReadOnly
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

        #region Business Validations

        // TODO: Add methods here.
        #endregion
    }
}