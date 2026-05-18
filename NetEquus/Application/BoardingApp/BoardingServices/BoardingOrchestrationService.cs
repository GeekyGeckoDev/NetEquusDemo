using Application.BoardingApp.IBoardingServices;
using Domain.Entities.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BoardingApp.BoardingServices
{
    public class BoardingOrchestrationService : IBoardingOrchestrationService
    {
        private readonly IBoardingCrudService _boardingCrudService;

        public BoardingOrchestrationService(IBoardingCrudService boardingCrudService)
        {
            _boardingCrudService = boardingCrudService;
        }

        public async Task CreateLinkEstateToHorse (Guid EstateId, Guid HorseId)
        {
            var boarding = new HorseBoarding
            {
                BoardingEstateId = EstateId,
                HorseGuidId = HorseId
            };

            await _boardingCrudService.CreateHorseBoardingAsync (boarding);
        }
    }
}
