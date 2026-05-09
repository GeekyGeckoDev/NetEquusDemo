using Application.BreedApp.IBreedServices;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.BreedDtos;

namespace APIBreed.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreedController : ControllerBase
    {
        private readonly IBreedOrchestrationService _breedOrchestrationService;

        public BreedController(IBreedOrchestrationService breedOrchestrationService)
        {
            _breedOrchestrationService = breedOrchestrationService;
        }

        [HttpPost("breedcreation")]
        public async Task<IActionResult> CreateBreedAsync([FromBody] BreedDto dto)
        {
            var result = await _breedOrchestrationService.CreateBreedAsync(dto);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
