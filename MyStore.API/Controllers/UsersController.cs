using Microsoft.AspNetCore.Mvc;
using MyStore.API.Models;
using MyStore.API.Services;

namespace MyStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _usersService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserById([FromRoute] Guid id)
        {
            var user = await _usersService.GetUserById(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser(User user)
        {
            await _usersService.AddUsers(user);
            return Ok();
        }
    }
}