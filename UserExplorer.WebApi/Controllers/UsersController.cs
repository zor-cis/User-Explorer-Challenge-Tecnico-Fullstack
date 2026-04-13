using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserExplorer.Core.Application.DTOs.User;
using UserExplorer.Core.Application.Interfaces;

namespace UserExplorer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto createDto)
        {
            if (createDto == null)
                return BadRequest("User data is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.AddUser(createDto);

            return Created("", createDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponseDto))]
        public async Task<IActionResult> GetUsers([FromQuery] string? search, [FromQuery] string? company, [FromQuery] string? city)
        {
            if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(company) && string.IsNullOrEmpty(city))
            {
                var usersList = await _userService.GetAllUsers();
                return Ok(usersList);
            }
            var users = await _userService.GetUsersByFilters(search, company, city);
            return Ok(users);
        }
    }
}