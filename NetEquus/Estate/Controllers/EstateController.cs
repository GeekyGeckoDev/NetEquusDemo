using Application.EstateApp.EstateDtos;
using Application.EstateApp.IEstateServices.IEstateOrchestrationServices;
using Application.SharedApp.OwnershipDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.UserDtos;
using Shared.Dtos.WrapperDto;
using System.Security.Claims;

namespace APIEstate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstateController : ControllerBase
    {
        private readonly IEstateOrchestrationService _estateOrchestrationService;

        public EstateController(IEstateOrchestrationService estateService)

        {
            _estateOrchestrationService = estateService;
        }

        [HttpPost("estatecreation")]
        public async Task<IActionResult> CreateEstateAsync([FromBody] CreateEstateRequest estateDto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await _estateOrchestrationService.CreateEstateWithOwnership(userId, estateDto.Estate);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [Authorize]
        [HttpPost("npc-estatecreation")]
        public async Task <IActionResult> CreateNpcEstateAsync([FromBody] CreateNpcEstateRequest dto)
        {
            var result = await _estateOrchestrationService.CreateEstateWithOwnership(dto.UserId, dto.Estate);


            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);

        }


    }

  
}
