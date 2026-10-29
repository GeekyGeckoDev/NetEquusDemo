using Application.CompetitionApp.ICompetitionManagers;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.CompetitionDtos;

namespace APICompetition.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitionEntryController : ControllerBase
    {

        private readonly ICompetitionManager _competitionManager;

        public CompetitionEntryController(ICompetitionManager competitionManager)
        {
            _competitionManager = competitionManager;
        }

        [HttpPost("createCompetitionEntry")]
        public async Task<IActionResult> CreateCompetitionEntryAsync([FromBody] CreateCompetitionEntryDto dto)
        {
            var result = await _competitionManager.CreateCompetitionEntryAsync(dto);

            if (!result.IsAllowed)
            {
                return BadRequest(result.Message);
            }
            return Ok("Competition entry created successfully.");
        }

    }
}
