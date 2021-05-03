using System.Collections.Generic;
using UserService.Entities;

namespace UserService.Repositories
{
    public class UserRepository:IUserRepository
    {
        private List<User> allUsers;

        public UserRepository()
        {
            allUsers = new List<User> {
                new User
                {
                    Id = 1,
                    FirstName = "Enes",
                    LastName = "Demir",
                    Email = "enes@demir.com"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Alper",
                    LastName = "Tunga",
                    Email = "alper@tunga.com"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Seyyit",
                    LastName = "Atım",
                    Email = "seyyit@atim.com"
                },
            };
        }
        public IEnumerable<User> GetAllUsers()
        {
            return allUsers;
        }

        public User GetUserById(int userId)
        {
            var foundUser = allUsers.Find(user => user.Id == userId);
            return foundUser;
        }

        public User CreateUser(User newUser)
        {
            newUser.Id = allUsers.Count + 1;
            allUsers.Add(newUser);
            return newUser;
        }

        public User UpdateUser(int userId, User newUser)
        {
            var foundUser = allUsers.Find(user => user.Id == userId);
            if (foundUser == null)
            {
                return null;
            }
            foundUser.FirstName = newUser.FirstName;
            foundUser.LastName = newUser.LastName;
            foundUser.Email = newUser.Email;
            return foundUser;
        }

        public bool DeleteUser(int userId)
        {
            var foundUser = allUsers.Find(user => user.Id == userId);
            if (foundUser == null)
            {
                return false;
            }
            allUsers.Remove(foundUser);
            return true;
        }
    }
}