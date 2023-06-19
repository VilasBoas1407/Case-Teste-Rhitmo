using Api.Domain.Interfaces.Services;
using Api.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public IActionResult GetUsers ([FromQuery] string? name)
        {
            var users = userService.GetUsers(name);

            if (users.Count == 0)
                return NoContent();

            return Ok(users);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] InsertUserModel user)
        {
            var response = userService.RegisterUser(user);

            if (response.IsSuccessStatusCode)
                return NoContent();
            else
            {
                var content = new { message = response.Content.ReadAsStringAsync().Result };
                return BadRequest(content);
            }

        }

        [HttpPut]
        public IActionResult PutUser([FromBody] InsertUserModel userModel)
        {
            var response = userService.RegisterUser(userModel);

            if (response.IsSuccessStatusCode)
                return NoContent();
            else
            {
                var content = new { message = response.Content.ReadAsStringAsync().Result };
                return BadRequest(content);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var response = userService.DeleteUser();

            if (response.IsSuccessStatusCode)
                return NoContent();
            else
            {
                var content = new { message = response.Content.ReadAsStringAsync().Result };
                return BadRequest(content);
            }

        }
    }
}
