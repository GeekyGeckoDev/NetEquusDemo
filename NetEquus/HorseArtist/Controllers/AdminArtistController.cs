using Application.HorseArtistApp.IHorseArtistServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.HorseArtistDtos;
using System.Security.Claims;

namespace APIArtist.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdminArtistController : ControllerBase
    {
        public readonly IHorseArtistGetService _hAGetService;
        private readonly IHorseArtistOrchestrationService _hAOrchestrationService;

        public AdminArtistController(IHorseArtistGetService haGetService, IHorseArtistOrchestrationService hAOrchestrationService)
        {
            _hAGetService = haGetService;
            _hAOrchestrationService = hAOrchestrationService;
        }

        [Authorize]
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingList()
        {
            var artists = await _hAGetService
                .GetPendingArtistsAsync();

            return Ok(artists);
        }

        [Authorize]
        [HttpPatch("approve/{artistId}")]

        public async Task<IActionResult> ApproveArtistAsync (Guid artistId)
        {
            var result = await _hAOrchestrationService.ApprovePendingArtistAsync(artistId);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }

    }
}


