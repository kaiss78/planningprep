using PlanningPrep.Models.Users;

namespace PlanningPrep.Data.Users
{
    public interface IUserDAO : IDataAccess<User>
    {
        bool IsUserAssignedToProject(long userId, long projectId);
        User GetByUserName(string userName);
    }
}