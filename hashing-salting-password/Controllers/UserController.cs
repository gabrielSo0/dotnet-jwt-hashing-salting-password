using hashing_salting_password.Models;
using hashing_salting_password.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hashing_salting_password.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if(user is null) return NotFound("User not found.");

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
        public async Task<IActionResult> DeleteUser(int id)
        {
            var isSuccess = await _userService.DeleteUser(id);

            if(!isSuccess) NotFound();

            return NoContent();
        }
    }
}