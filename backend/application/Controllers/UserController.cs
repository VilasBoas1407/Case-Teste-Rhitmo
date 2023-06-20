using Api.Domain.Interfaces.Services;
using Api.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        /// <summary>
        /// Return a list of users
        /// </summary>
        /// <param name="name">Search for a specifc user by name</param>
        /// <response code="200">Return user data</response>
        /// <response code="404">Not found user</response>
        [HttpGet]
        public IActionResult GetUsers ([FromQuery] string? name)
        {
            var users = userService.GetUsers(name);

            if (users.Count == 0)
                return NotFound();

            return Ok(users);
        }

        /// <summary>
        /// Return data from a user by ID
        /// </summary>
        /// <param name="id">ID user</param>
        /// <response code="200">Return user data</response>
        /// <response code="404">Not found user</response>
        [HttpGet]
        [Route("${id}")]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            var user = userService.GetUser(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Create a new user register
        /// </summary>
        /// <param name="user">User data to register</param>
        /// <response code="200">Return user data</response>
        /// <response code="400">Return a erro message from data validation</response>
        [HttpPost]
        public IActionResult PostUser([FromBody] InsertUserModel user)
        {
            var response = userService.RegisterUser(user);

            if (response.IsSuccessStatusCode)
                return Ok(new { ID = response.Content.ReadAsStringAsync().Result });
            else
            {
                var content = new { message = response.Content.ReadAsStringAsync().Result };
                return BadRequest(content);
            }

        }


        /// <summary>
        /// Edit a user register
        /// </summary>
        /// <param name="user">User data to register</param>
        /// <response code="200">Return user data</response>
        /// <response code="400">Return a erro message from data validation</response>
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

        /// <summary>
        /// Delete user by ID
        /// </summary>
        /// <param name="ID">User ID to delete</param>
        /// <response code="204">User deleted</response>
        /// <response code="404">User not found</response>  
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            var response = userService.DeleteUser(id);

            if (response.IsSuccessStatusCode)
                return NoContent();
            else
                return NotFound();

        }
    }
}
