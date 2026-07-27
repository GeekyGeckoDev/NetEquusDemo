using Application.SharedApp.BreedingServices;
using Application.SharedApp.FoalingHorseApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.FolaingDtos;
using Shared.Dtos.HorseDtos;
using System.Security.Claims;

namespace APIFoaling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoalingController : ControllerBase
    {
        private readonly IFoalingHorseManagerService _manager;
        private readonly IBreedListService _breedListService;

        public FoalingController(IFoalingHorseManagerService manager, IBreedListService breedListService)
        {
            _manager = manager;
            _breedListService = breedListService;
        }

        [Authorize]
        [HttpPost("create-foaling")]
        public async Task<IActionResult> CreateFoalingOrchestrateAsync (CreateFoalingDto dto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await _manager.CreateHorseOwnershipBoardingFoalingAsync (userId,dto.MareId, dto.StallionId);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("get-eligible-mares")]
        public async Task<IActionResult> GetEligibleMaresAsync ()
        {

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var mares = await _breedListService.GetEligibleBreedingMaresAsync (userId);

            return Ok(mares);
        }

        [Authorize]
        [HttpGet("get-eligible-stallions/{damId}")]
        public async Task<IActionResult> GetEligibleStallionsAsync (Guid damId)
        {
            var stallions = await _breedListService.GetEligibleStallionsAsync(damId);
            return Ok(stallions);
        }


    }
}