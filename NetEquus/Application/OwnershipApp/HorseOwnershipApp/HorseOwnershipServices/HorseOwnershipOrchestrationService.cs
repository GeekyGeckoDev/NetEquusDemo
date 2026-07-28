using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using Domain.Entities.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OwnershipApp.HorseOwnershipApp.HorseOwnershipServices
{
    public class HorseOwnershipOrchestrationService : IHorseOwnershipOrchestrationService
    {
        private readonly IHorseOwnershipCrudService _horseOwnershipCrudService;

        public HorseOwnershipOrchestrationService(IHorseOwnershipCrudService horseOwnershipCrudService)
        {
            _horseOwnershipCrudService = horseOwnershipCrudService;
        }

        public async Task CreateLinkUserToHorseAsync (Guid userId, Guid horseId)
        {
            var ownership = new HorseOwnership
            {
                UserId = userId,
                HorseGuidId = horseId
            };

            await _horseOwnershipCrudService.CreateHorseOwnershipAsync (ownership);
        }
    }
}
