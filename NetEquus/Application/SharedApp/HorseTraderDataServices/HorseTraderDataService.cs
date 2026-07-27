using Application.BoardingApp.IBoardingServices;
using Application.EstateApp.IEstateServices.IEstateCrudServices;
using Application.UserApp.NpcServices;
using Shared.Dtos.BoardingDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SharedApp.HorseTraderDataServices
{
    public class HorseTraderDataService : IHorseTraderDataService
    {
        private readonly INpcManagerService _npcManagerService;
        private readonly IBoardingGetService _boardingGetService;

        public HorseTraderDataService (INpcManagerService npcManagerService, IBoardingGetService boardingGetService)
        {
            _npcManagerService = npcManagerService;
            _boardingGetService = boardingGetService;
        }

        public async Task<List<BoardingDto>> GetHorsesAtHorseTraderAsync ()
        {
            var traderOwnership = await _npcManagerService.GetHorseTraderDataAsync();

            return await _boardingGetService.GetBoardingByEstateIdAsync((Guid)traderOwnership.EquineEstateId);


        }
    }
}
