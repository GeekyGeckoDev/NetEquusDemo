using Application.HorseArtistApp.IHorseArtistServices;
using Domain.Entities.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIArtist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IHorseArtistOrchestrationService _hAOrchestrationService;

        public ArtistController(IHorseArtistOrchestrationService hAOrchestrationService)
        {
            _hAOrchestrationService = hAOrchestrationService;
        }

        [HttpPost("artistcreation")]
       public async Task<IActionResult> CreateArtistAsync ()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!Guid.TryParse(userIdClaim, out var userId))
                return Unauthorized();

            var result = await _hAOrchestrationService.ValidateAndCreateHorseArtist(userId);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
