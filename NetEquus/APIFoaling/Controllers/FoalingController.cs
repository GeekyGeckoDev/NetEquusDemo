using Application.SharedApp.FoalingHorseApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.FolaingDtos;

namespace APIFoaling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoalingController : ControllerBase
    {
        private readonly IFoalingHorseManagerService _manager;

        public FoalingController(IFoalingHorseManagerService manager)
        {
            _manager = manager;
        }

        [Authorize]
        [HttpPost("create-foaling")]
        public async Task<IActionResult> CreateFoalingOrchestrateAsync (CreateFoalingDto dto)
        {
            var result = await _manager.CreateHorseOwnershipBoardingFoalingAsync (dto.MareId, dto.StallionId);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
