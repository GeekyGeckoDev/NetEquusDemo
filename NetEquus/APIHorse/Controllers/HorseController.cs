using Application.HorseApp.IHorseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.HorseDtos;

namespace APIHorse.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HorseController : ControllerBase
    {
        private readonly IHorseOrchestrationService _horseOrchestrationService;
        private readonly IHorseGetService _service;

        public HorseController(IHorseOrchestrationService horseOrchestrationService, IHorseGetService service)
        {
            _horseOrchestrationService = horseOrchestrationService;
            _service = service;
        }

        [Authorize]
        [HttpPost("generate-horse")]
        public async Task<IActionResult> GenerateHorseAsync ()
        {
            var result = await _horseOrchestrationService.GenerateHorseWithOwnershipAsync();

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("mares")]
        public async Task<IActionResult> GetMaresAsync()
        {
            var mares = await _service.GetMaresAsync();

            return Ok(mares);
        }

        [HttpGet("stallions")]
        public async Task<IActionResult> GetStallionsAsync()
        {
            var stallions = await _service.GetStallionsAsync();


            return Ok(stallions);
        }

        [HttpGet("get-pedigree/{horseId},{generations}")]
        public async Task<PedigreeDto> GetPedigree(Guid horseId, int generations)
        {
            return await _service.BuildPedigreeAsync(horseId, generations);
        }
    }
}


