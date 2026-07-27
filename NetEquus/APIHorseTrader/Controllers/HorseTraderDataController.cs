using Application.SharedApp.HorseTraderDataServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.BoardingDtos;

namespace APIHorseTrader.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorseTraderDataController : ControllerBase
    {
        private readonly IHorseTraderDataService _horseTraderDataService;

        public HorseTraderDataController (IHorseTraderDataService horseTraderDataService)
        {
            _horseTraderDataService = horseTraderDataService;
        }

        [Authorize]
        [HttpGet("get-horses-horsetrader")]
        public async Task<ActionResult<List<BoardingDto>>> HorsetraderBoardingsAsync ()
        {
            var horseList = await _horseTraderDataService.GetHorsesAtHorseTraderAsync();

            return Ok(horseList);
        }
    }
}
