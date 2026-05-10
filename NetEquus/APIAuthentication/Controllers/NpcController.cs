using Application.UserApp.NpcServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.NpcDtos;

namespace APIAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NpcController : ControllerBase
    {
        private readonly INpcManagerService _npcManagerService;

        public NpcController(INpcManagerService npcManagerService)
        {
            _npcManagerService = npcManagerService;
        }

        [Authorize]
        [HttpPost("createnpc")]
        public async Task<IActionResult> CreateNpcAsync([FromBody] CreateNpcDto dto)
        {
            var result = await _npcManagerService.CreateNpcUserAsync(dto);

            if (!result.IsAllowed)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("getnpcswithoutestates")]
        public async Task<IActionResult> GetNpcsWithoutEstates ()
        {
            var result = await _npcManagerService.GetNpcsWithoutEstatesAsync();


            return Ok(result);
        }

    }
}
