using System.Collections.Generic;
using UserService.Entities;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        User CreateUser(User newUser);
        User UpdateUser(int userId, User newUser);
        bool DeleteUser(int userId);
    }
}