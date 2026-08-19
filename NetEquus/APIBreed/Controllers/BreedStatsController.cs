using Application.BreedApp.BreedStatsApp;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.WrapperDto;

namespace APIBreed.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreedStatsController : ControllerBase
    {
        private readonly IBreedGenMinMaxService _minMaxStatService;

        public BreedStatsController(IBreedGenMinMaxService minMaxStatService)
        {
            _minMaxStatService = minMaxStatService;
        }


        [HttpPatch("updateGenStats/{breedId}")]
        public async Task<IActionResult> UpdateBreedGenProfileAsync(
     Guid breedId,
     [FromBody] BreedGenerationProfileDto dto)
        {
            if (breedId != dto.BreedId)
                return BadRequest("BreedId mismatch.");

            await _minMaxStatService.UpdateBreedGenProfileAsync(dto);

            return Ok();
        }
    }
}
