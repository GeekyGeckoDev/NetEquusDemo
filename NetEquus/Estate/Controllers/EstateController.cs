using Application.EstateApp.EstateDtos;
using Application.EstateApp.IEstateServices.IEstateCrudServices;
using Application.EstateApp.IEstateServices.IEstateOrchestrationServices;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices;
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
        private readonly IEstateOwnershipGetService _estateOwnershipGetService;
        private readonly IEstateGetService _estateGetService;

        public EstateController(IEstateOrchestrationService estateService, IEstateOwnershipGetService estateOwnershipGetService, IEstateGetService estateGetService)

        {
            _estateOrchestrationService = estateService;
            _estateOwnershipGetService = estateOwnershipGetService;
            _estateGetService = estateGetService;
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

        [HttpGet("get-estate-ownership-by-userid/{userId}")]
        public async Task<IActionResult> GetEstateOwnershipByUserId(Guid userId)
        {
            var ownership = await _estateOwnershipGetService.GetEstateOwnershipByUserIdAsync(userId);

            return Ok(ownership);
        }

        [HttpGet("get-all-estates")]
        public async Task<IActionResult> GetAllEstatesAsync ()
        {
            var estates = await _estateGetService.GetAllEstatesAsync();

            return Ok(estates);
        }
    }

  
}
