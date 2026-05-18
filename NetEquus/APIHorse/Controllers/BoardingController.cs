using Application.BoardingApp.IBoardingServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIHorse.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BoardingController : ControllerBase
    {
        private readonly IBoardingGetService _service;

        public BoardingController(IBoardingGetService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet("get-npc-horseboardings/{estateId}")]
        public async Task<IActionResult> HorseBoardingsListAsync (Guid estateId)
        {

            var boardings = await _service.GetBoardingByEstateIdAsync(estateId);

            return Ok(boardings);
        }

   
    }
}
