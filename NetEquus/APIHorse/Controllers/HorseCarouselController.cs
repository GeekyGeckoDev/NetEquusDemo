using Application.HorseApp.IHorseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.HorseDtos;

namespace APIHorse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorseCarouselController : ControllerBase
    {
        private readonly IHorseOrchestrationService _horseOrchestrationService;
        private readonly IHorseGetService _service;

        public HorseCarouselController(IHorseOrchestrationService horseOrchestrationService, IHorseGetService service)
        {
            _horseOrchestrationService = horseOrchestrationService;
            _service = service;
        }

        [HttpGet("get-random-horses")]
        public async Task<IActionResult> GetRandomHorsesAsync()
        {
            var horses = await _service.GetRandomHorsesAsync();

            return Ok(horses);
        }
        
    }
}
