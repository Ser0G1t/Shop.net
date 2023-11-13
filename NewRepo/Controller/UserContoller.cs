using Microsoft.AspNetCore.Mvc;
using NewRepo.DTO;
using NewRepo.IService;

namespace NewRepo.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserContoller : ControllerBase
    {
        private readonly IUserService _userService;

        public UserContoller(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("create_user")]
        public ActionResult createUser([FromBody] CreateUserDTO user)
        {
            _userService.createUser(user);
            return Ok("User has been created");
        }
    }
}
