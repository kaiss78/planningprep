using App.Models.Users;

namespace App.Data.Users
{
    public interface IUserDAO : IDataAccess<User>
    {
        bool IsUserAssignedToProject(long userId, long projectId);
        User GetByUserName(string userName);
    }
}