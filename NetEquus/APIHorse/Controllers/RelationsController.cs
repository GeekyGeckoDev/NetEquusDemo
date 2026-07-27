using Application.HorseApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIHorse.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RelationsController : ControllerBase
    {
        private readonly IHorseRelations _horseRelations;

        public RelationsController(IHorseRelations horseRelations)
        {
            _horseRelations = horseRelations;
        }
        [Authorize]
        [HttpPatch("update/{horseId},{newEstateId}")]
        public async Task<IActionResult> UpdateBoardingAndOwnership (Guid horseId, Guid newEstateId)
        {
            var result = await _horseRelations.UpdateBoardingAndOwnershipAsync(horseId, newEstateId);
            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
