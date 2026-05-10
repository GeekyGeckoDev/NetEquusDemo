using Application.BreedApp.IBreedServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.BreedDtos;

namespace APIBreed.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreedController : ControllerBase
    {
        private readonly IBreedOrchestrationService _breedOrchestrationService;
        private readonly IBreedGetService _breedGetService;

        public BreedController(IBreedOrchestrationService breedOrchestrationService, IBreedGetService breedGetService)
        {
            _breedOrchestrationService = breedOrchestrationService;
            _breedGetService = breedGetService;
        }

        [HttpPost("breedcreation")]
        public async Task<IActionResult> CreateBreedAsync([FromBody] BreedDto dto)
        {
            var result = await _breedOrchestrationService.CreateBreedAsync(dto);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }

 
        [HttpGet("breedslist")]
        public async Task<IActionResult> GetAllBreedsAsync()
        {
            var breeds = await _breedGetService
                .GetAllBreedsAsync();

            return Ok(breeds);
        }

        [HttpPatch("update/{breedId}")]
        public async Task<IActionResult> UpdateBreedAsync (Guid breedId)
        {
            var result = await _breedOrchestrationService.UpdateBreedAsync(breedId);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
