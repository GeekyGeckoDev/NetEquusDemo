using Application.UserApp.IUserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.UserDtos;

namespace APIAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRegistration : ControllerBase
    {
        private readonly IUserManagerService _userManagerService;

        public UserRegistration(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegistrationDto dto)
        {
            var result = await _userManagerService.RegisterUserAsync(dto);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}


