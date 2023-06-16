using Api.Domain.Interfaces.Services;
using Api.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController() { }

        [HttpGet]
        public IActionResult GetUsers([FromServices] IUserService userService, [FromQuery] string name)
        {
            var users = userService.GetUsers(name);

            if (users.Count == 0)
                return NoContent();

            return Ok(users);
        }
    }
}
