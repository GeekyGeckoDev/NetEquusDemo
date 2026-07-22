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
        private readonly IHorseSaleManagerService _horseSaleManagerService;

        public TransactionController(IHorseSaleManagerService horseSaleManagerService)
        {
            _horseSaleManagerService = horseSaleManagerService;
        }

        [Authorize]
        [HttpPost("horse-sale")]

        public async Task<IActionResult> CreateHorseTraderSale (HorseTraderRequest request)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await _horseSaleManagerService.FinalizeHorseTraderSaleAsync(request);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);

        }
    }
}
