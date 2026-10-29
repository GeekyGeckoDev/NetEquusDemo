using Application.CompetitionApp.ICompetitionManagers;
using Application.CompetitionApp.ICompetitionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.CompetitionDtos;

namespace APICompetition.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionManager _competitionManager;
        private readonly ICompetitionCrudService _competitionCrudService;

        public CompetitionController(ICompetitionManager competitionManager, ICompetitionCrudService competitionCrudService)
        {
            _competitionManager = competitionManager;
            _competitionCrudService = competitionCrudService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("createCompetition")]
        public async Task<IActionResult> CreateCompetitionAsync([FromBody] CreateCompetitionDto dto)
        {
            var result = await _competitionManager.CreateCompetitionAsync(dto);

            if (!result.IsAllowed)
            {
                return BadRequest(result.Message);
            }
            return Ok("Competition created successfully.");
        }

        [HttpGet("competitionList")]
        public async Task<IActionResult> getAllCompetitionsAsync()
        {
            var competitions = await _competitionCrudService.GetAllCompetitionsAsync();
            return Ok(competitions);
        }
    }
}
