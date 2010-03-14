


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Comment
 * Purpose: Comment entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Shubho	3/14/2010 3:21:07 AM		Initial Code
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
    public class Comment : BaseEntity
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
        /// Gets or sets the QuestionID
        /// </summary>
        /// <value>The QuestionID.</value>
        public int QuestionID
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
        /// Gets or sets the CommentText
        /// </summary>
        /// <value>The CommentText.</value>
        public string CommentText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Rank
        /// </summary>
        /// <value>The Rank.</value>
        public int Rank
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

        /// <summary>
        /// Gets or sets the Modified
        /// </summary>
        /// <value>The Modified.</value>
        public DateTime Modified
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
