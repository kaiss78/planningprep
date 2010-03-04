#region File Info/History
/*
 * --------------------------------------------------------------------------------
 * Project Name: [Project Name]
 * Module: [Assembly Name]
 * Name: UserActivity.cs
 * Purpose: DAO Class to get/set the data from UserActivitys Table
 * 
 * Author: [Developer Name]
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * User					Date					Comments
 * [Developer Name]		01/10/2010 17:37:27		Initial Development
 * -------------------------------------------------------------------------------- 
 */
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using PlanningPrep.Models.Enums;
using PlanningPrep.Models.Users;
using PlanningPrep.Core;
using PlanningPrep.Core.DB;
using PlanningPrep.Core.Factories;

namespace PlanningPrep.Data.Users
{
    public class UserActivityDAO : BaseDataAccess<UserActivity>, IUserActivityDAO
    {
        #region Constructor
        public UserActivityDAO()
        {
        }

        public UserActivityDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        /// <summary>
        /// Gets all for user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public List<UserActivity> GetAllForUser(long userId)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", GetType().Name + ".GetAllForUser(long)"))
            {
                List<UserActivity> activities = new List<UserActivity>();
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("UserId", DbType.Int64, userId) };
                    activities = GetAllInternal("sp" + typeof(UserActivity).Name + "GetByUserId", parameters, true);
                }
                catch (Exception ex)
                {
                    HandleDataAccessException(ex, GetType().Name + ".GetAllForUser(long)");
                }
                return activities;
            }
        }

        /// <summary>
        /// Gets the type of all for activity.
        /// </summary>
        /// <param name="activityType">Type of the activity.</param>
        /// <returns></returns>
        public List<UserActivity> GetAllForActivityType(ActivityType activityType)
        {
            using (new TimedTraceLog(CurrentUser != null ? CurrentUser.Identity.Name : "", GetType().Name + ".GetAllForUser(long)"))
            {
                List<UserActivity> activities = new List<UserActivity>();
                try
                {
                    DbParameter[] parameters = new[] { new DbParameter("ActivityType", DbType.Int32, activityType) };
                    activities = GetAllInternal("sp" + typeof(UserActivity).Name + "GetByActivityType", parameters, true);
                }
                catch (Exception ex)
                {
                    HandleDataAccessException(ex, GetType().Name + ".GetAllForUser(long)");
                }
                return activities;
            }
        }



        #region Helper Methods
        protected override UserActivity Map(IDataReader reader)
        {
            UserActivity entity = EntityFactory.Create<UserActivity>();

            entity.Id = NullHandler.GetLong(reader["Id"]);
            entity.UserId = NullHandler.GetLong(reader["UserId"]);
            entity.ActivityType = NullHandler.GetEnum<ActivityType>(reader["ActivityType"]);
            entity.ActivityTime = NullHandler.GetDateTime(reader["ActivityTime"]);
            entity.IPAddress = NullHandler.GetString(reader["IPAddress"]);
            entity.RequestedUrl = NullHandler.GetString(reader["RequestedURL"]);
            entity.SessionId = NullHandler.GetString(reader["SessionId"]);
            entity.RefUrl = NullHandler.GetString(reader["RefUrl"]);
            entity.Browser = NullHandler.GetString(reader["Browser"]);
            entity.ShortMessage = NullHandler.GetString(reader["ShortMessage"]);
            entity.LongMessage = NullHandler.GetString(reader["LongMessage"]);
            entity.Active = NullHandler.GetBoolean(reader["Active"]);
            entity.Deleted = NullHandler.GetBoolean(reader["Deleted"]);
            entity.Locked = NullHandler.GetBoolean(reader["Locked"]);
            entity.DatetimeStamp = NullHandler.GetDateTime(reader["DatetimeStamp"]);

            return entity;
        }

        protected override void EagerLoad(UserActivity entity)
        {
            using(IUserDAO dao = (IUserDAO) DAOFactory.Get<User>())
            {
                entity.User = dao.Get(entity.UserId);
            }
        }

        /// <summary>
        /// Saves the reference properties before.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void SaveReferencePropertiesBefore(UserActivity entity)
        {
        }

        /// <summary>
        /// Saves the reference properties after.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void SaveReferencePropertiesAfter(UserActivity entity)
        {
        }

        #endregion
    }
}


