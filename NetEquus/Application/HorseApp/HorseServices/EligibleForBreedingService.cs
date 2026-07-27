using Application.BreedApp.IBreedServices;
using Application.HorseApp.IHorseServices;
using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseServices
{
    public class EligibleForBreedingService
    {
        private readonly IHorseGetService _horseGetService;
        private readonly IBreedGetService _breedGetService;

        public EligibleForBreedingService(IHorseGetService horseGetService, IBreedGetService breedGetService)
        {
            _horseGetService = horseGetService;
            _breedGetService = breedGetService;
        }

        //public async Task<List<HorseInfoDto>> GetAllElligibleMares ()
        //{

        //}

        //public async Task<List<HorseInfoDto>> GetAllElligibleStallion()
        //{

        //}
    }
}
