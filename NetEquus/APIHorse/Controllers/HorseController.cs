using Application.HorseApp.IHorseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIHorse.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HorseController : ControllerBase
    {
        private readonly IHorseOrchestrationService _horseOrchestrationService;

        public HorseController(IHorseOrchestrationService horseOrchestrationService)
        {
            _horseOrchestrationService = horseOrchestrationService;
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
    }
}
