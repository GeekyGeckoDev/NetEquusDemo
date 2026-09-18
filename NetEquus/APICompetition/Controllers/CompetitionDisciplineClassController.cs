using Application.CompetitionApp.ICompetitionDisciplineServices;
using Application.CompetitionApp.ICompetitionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.CompetitionDtos.CompDisciplineDtos;

namespace APICompetition.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitionDisciplineClassController : ControllerBase
    {
        private readonly ICompetitionDisciplineClassManager _competitionDisciplineClassManager;

        private readonly ICompetitionClassCrudService _competitionClassCrudService;
        public CompetitionDisciplineClassController(ICompetitionDisciplineClassManager competitionDisciplineClassManager, ICompetitionClassCrudService competitionClassCrudService)
        {
            _competitionDisciplineClassManager = competitionDisciplineClassManager;
            _competitionClassCrudService = competitionClassCrudService;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("competitiondisciplinesclass")]
        public async Task<IActionResult> CreateCompetitionDisciplineWithClassAsync(
            [FromBody] CreateCompetitionDisciplineWithClassDto dto)
        {
            var result = await _competitionDisciplineClassManager.CreateCompetitionDisciplineWithClassAsync(dto);

            if (!result.IsAllowed)
            {
                return BadRequest(result.Message);
            }
            return Ok("Competition Discipline with Class created successfully.");

        }

        [HttpGet("getCompetitionClasses")]
        public async Task<IActionResult> GetCompetitionClassesAsync()
        {
            // Assuming you have a method to get all competition classes
            var competitionClasses = await _competitionClassCrudService.GetAllCompetitionClassesAsync();
            return Ok(competitionClasses);
        }
    }
}