using Application.CycleApp.DailyChecks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.UserDtos;
using System.Security.Claims;

namespace APIFoaling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessFoalingController : ControllerBase
    {
        private readonly IFoalingCheckService _foalingCheckService;

        public ProcessFoalingController(IFoalingCheckService foalingCheckService)
        {
            _foalingCheckService = foalingCheckService;
        }

        [Authorize]
        [HttpPost("process-due-foalings")]
        public async Task<IActionResult> ProcessDueFoalingsAsync ()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _foalingCheckService.ProcessDueFoalingsAsync(userId);

            return Ok();
        }
 


    }
}
