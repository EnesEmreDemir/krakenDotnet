using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserService.Entities;
using UserService.Repositories;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return new ObjectResult(_userRepository.GetAllUsers());
        }


        [HttpGet("{userId}")]
        public ActionResult<User> Get(int userId)
        {
            return new ObjectResult(_userRepository.GetUserById(userId));
        }


        [HttpPost]
        public ActionResult<User> Post([FromBody] User newUser)
        {
            return new ObjectResult(_userRepository.CreateUser(newUser));
        }


        [HttpPut("{userId}")]
        public ActionResult<User> Put(int userId, [FromBody] User dirtyUser)
        {
            var foundUser = _userRepository.UpdateUser(userId, dirtyUser);
            if (foundUser == null)
            {
                return new NotFoundObjectResult(dirtyUser);
            }
            return foundUser;
        }


        [HttpDelete("{userId}")]
        public ActionResult Delete(int userId)
        {
            var isDeleted = _userRepository.DeleteUser(userId);
            if (!isDeleted)
            {
                return new NotFoundObjectResult(userId);
            }
            return new OkResult();
        }
    }
}