using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipRepos;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using Domain.Entities.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OwnershipApp.HorseOwnershipApp.HorseOwnershipServices
{
    public class HorseOwnershipCrudService : IHorseOwnershipCrudService
    {
        private readonly IHorseOwnershipCrudRepository _hOCrudrepository;

        public HorseOwnershipCrudService(IHorseOwnershipCrudRepository hOCrudrepository)
        {
            _hOCrudrepository = hOCrudrepository;
        }

        public async Task CreateHorseOwnershipAsync (HorseOwnership horseOwnership)
        {
            await _hOCrudrepository.CreateHorseOwnershipAsync(horseOwnership);
        }
    }
}
