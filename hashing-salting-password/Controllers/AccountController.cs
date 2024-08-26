using hashing_salting_password.Models;
using hashing_salting_password.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hashing_salting_password.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(User modelUser)
        {
            var user = await _userService.CreateUser(modelUser);

            if(user == null) BadRequest();

            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(User modelUser)
        {
            return null;
        }
    }
}