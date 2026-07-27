using Application.BoardingApp.IBoardingServices;
using Application.EstateApp.IEstateServices.IEstateCrudServices;
using Application.OwnershipApp.HorseOwnershipApp.HorseOwnershipServices;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using Application.UnitOfWorks;
using Domain.DomainRules;
using Shared.Mappers.BoardingMappers;
using Shared.Mappers.OwnershipMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp
{
    public class HorseRelations : IHorseRelations
    {
        IBoardingCrudService _boardingCrudService;
        IBoardingGetService _boardingGetService;
        IEstateGetService _estateGetService;
        IHorseOwnershipCrudService _horseOwnershipCrudService;
        IHorseOwnershipGetService _horseOwnershipGetService;
        IUnitOfWork _unitOfWork;

        public HorseRelations(IBoardingCrudService boardingCrudService, IBoardingGetService boardingGetService, IHorseOwnershipCrudService horseOwnershipCrudService, IHorseOwnershipGetService horseOwnershipGetService, IEstateGetService estateGetService, IUnitOfWork unitOfWork)
        {
            _boardingCrudService = boardingCrudService;
            _boardingGetService = boardingGetService;
            _horseOwnershipGetService = horseOwnershipGetService;
            _horseOwnershipCrudService = horseOwnershipCrudService;
            _estateGetService = estateGetService;
            _unitOfWork = unitOfWork;
        }

        public async Task<RuleResult> UpdateBoardingAndOwnershipAsync(
    Guid horseId,
    Guid newEstateId)
        {
            try
            {
                var boarding =
                    await _boardingGetService.GetBoardingByHorseIdAsync(horseId);

                boarding.BoardingEstateId = newEstateId;

                await _boardingCrudService
                    .UpdateBoardingAsync(boarding);

                var estate =
                    await _estateGetService
                        .GetEstateByIdAsync(newEstateId);

                var ownership =
                    await _horseOwnershipGetService
                        .GetOwnershipByHorseIdAsync(horseId);



                var estateOwner =
                    estate.EstateOwners.FirstOrDefault();

                if (estateOwner == null)
                    throw new Exception("Estate has no owner.");

                ownership.UserId = estateOwner.UserId;

                await _horseOwnershipCrudService
                    .UpdateHorseOwnershipAsync(ownership);


                return RuleResult.Success();
            }

            catch (Exception ex)
            {
                return RuleResult.Fail("ex");
            }


            
                
        }
    }

   
}
