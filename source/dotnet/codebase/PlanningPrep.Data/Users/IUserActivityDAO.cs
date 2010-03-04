using System.Collections.Generic;
using PlanningPrep.Models.Enums;
using PlanningPrep.Models.Users;

namespace PlanningPrep.Data.Users
{
    public interface IUserActivityDAO : IDataAccess<UserActivity>
    {
        /// <summary>
        /// Gets all for user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        List<UserActivity> GetAllForUser(long userId);
        /// <summary>
        /// Gets the type of all for activity.
        /// </summary>
        /// <param name="activityType">Type of the activity.</param>
        /// <returns></returns>
        List<UserActivity> GetAllForActivityType(ActivityType activityType);
    }
}