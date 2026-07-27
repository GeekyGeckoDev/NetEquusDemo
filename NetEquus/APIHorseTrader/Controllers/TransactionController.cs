using Application.SharedApp.HorseSaleApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.WrapperDto;
using System.Security.Claims;

namespace APIHorseTrader.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IHorseTraderManagerService _horseTraderManagerService;

        public TransactionController(IHorseTraderManagerService horseTraderManagerService)
        {
            _horseTraderManagerService = horseTraderManagerService;
        }

        [Authorize]
        [HttpPatch("buy-horse/{horseId}")]

        public async Task<IActionResult> BuyHorseTraderSale(Guid horseId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await _horseTraderManagerService.BuyHorseAsync(userId, horseId);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);

        }

        [Authorize]
        [HttpPatch("sell-horse/{horseId}")]

        public async Task<IActionResult> SellHorseTraderSale(Guid horseId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await _horseTraderManagerService.SellHorseAsync(userId, horseId);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);

        }



    }
}
