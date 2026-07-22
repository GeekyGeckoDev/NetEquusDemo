using Application.SharedApp.HorseSaleApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.WrapperDto;

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
        [HttpPatch("horse-sale")]

        public async Task<IActionResult> HorseSaleAsync (HorseTraderRequest request)
        {
            var result = await _horseSaleManagerService.FinalizeHorseTraderSaleAsync(request);
            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
