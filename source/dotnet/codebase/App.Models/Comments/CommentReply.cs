#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		CommentReply
 * Purpose: CommentReply entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/23/2010 10:00:40 PM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;

namespace App.Models.Comments
{
    [Serializable]
    public class CommentReply : BaseEntity
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        /// <value>The ID.</value>
        public long ID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the CommentID
        /// </summary>
        /// <value>The CommentID.</value>
        public long CommentID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        /// <value>The Message.</value>
        public String Message
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the UserID
        /// </summary>
        /// <value>The UserID.</value>
        public int UserID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Created
        /// </summary>
        /// <value>The Created.</value>
        public DateTime Created
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

        #region Override Methods
        // TODO: Add override methods here.
        #endregion
    }
}
