using Application.BoardingApp.IBoardingServices;
using Application.BreedApp.IBreedServices;
using Application.EstateApp.IEstateServices.IEstateCrudServices;
using Application.HorseApp.IHorseServices;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using Application.UserApp.IUserServices.IUserCrudServices;
using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SharedApp.BreedingServices
{
    public class BreedListService : IBreedListService
    {
        private readonly IBreedlistRepository _breedlistRepository;
        private readonly IBoardingGetService _boardingGetService;
        private readonly IUserGetService _userGetService;
        private readonly IEstateOwnershipGetService _estateOwnershipGetService;
        private readonly IBreedGetService _breedGetService;
        private readonly IHorseGetService _horseGetService;

        public BreedListService(IBreedlistRepository breedlistRepository, IBoardingGetService boardingGetService, IUserGetService userGetService, IEstateOwnershipGetService estateOwnershipGetService, IBreedGetService breedGetService, IHorseGetService horseGetService)
        {
            _breedlistRepository = breedlistRepository;
            _boardingGetService = boardingGetService;
            _userGetService = userGetService;
            _estateOwnershipGetService = estateOwnershipGetService;
            _breedGetService = breedGetService;
            _horseGetService = horseGetService;
        }

        public async Task<List<HorseInfoDto>> GetEligibleBreedingMaresAsync (Guid userId)
        {

            var ownerestate = await _estateOwnershipGetService.GetEstateOwnershipByUserIdAsync(userId);

            var mares = await _boardingGetService.GetEligibleMaresAsync((Guid)ownerestate.EquineEstateId);

            return mares;
        }

        public async Task<List<HorseInfoDto>> GetEligibleStallionsAsync (Guid damId)
        {
            var mare = await _horseGetService.GetHorseByIdAsync(damId);
            var breed = await _breedGetService.GetBreedByIdAsync(mare.BreedId);
            return await _breedlistRepository.GetEligibleStallionsAsync(damId, breed.BreedID);
        }
    }
}
