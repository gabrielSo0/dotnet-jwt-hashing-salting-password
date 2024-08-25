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

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User modelUser)
        {
            var user = await _userService.UpdateUser(modelUser);

            if(user == null) NotFound();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var isSuccess = await _userService.DeleteUser(id);

            if(!isSuccess) NotFound();

            return NoContent();
        }
    }
}