using Application.EstateApp.EstateMappers;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices;
using Application.SharedApp.OwnershipMappers;
using Application.UnitOfWorks;
using Application.UserApp.IUserServices;
using Domain.DomainRules;
using Shared.Dtos.NpcDtos;
using Shared.Dtos.OwnershipDtos;
using Shared.Dtos.UserDtos;
using Shared.Mappers.NpcMappers;
using Shared.Mappers.UserMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.NpcServices
{
    public class NpcManagerService : INpcManagerService
    {
        private readonly INpcInitilizationService _initilizationService;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserCrudService _userCrudService;

        private readonly INpcGetService _npcGetService;

        private readonly IEstateOwnershipGetService _estateGetService;
        public NpcManagerService(INpcInitilizationService npcInitilizationService, IUnitOfWork unitOfWork, IUserCrudService userCrudService, INpcGetService npcGetService, IEstateOwnershipGetService estateOwnershipGetService)
        {
            _initilizationService = npcInitilizationService;
            _unitOfWork = unitOfWork;
            _userCrudService = userCrudService;
            _npcGetService = npcGetService;
            _estateGetService = estateOwnershipGetService;
        }

        public async Task<RuleResult> CreateNpcUserAsync(CreateNpcDto dto)
        {
            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    await _initilizationService.NpcInitilizationAsync(dto);

                    var user = NpcMapper.ToNewNpc(dto);

                    await _userCrudService.CreateUserAsync(user);
                });
                return RuleResult.Success();
            }

            catch (Exception ex)
            {
                return RuleResult.Fail($"Estate creation failed: {ex.Message}");
            }
        }

        public async Task<List<NpcDto>> GetNpcsWithoutEstatesAsync()
        {
            var users = await _npcGetService.GHetUserByNpcStatusAsync(true);

            return [.. users.Select(NpcMapper.ToNpcDto)];


        }

        public async Task<EstateOwnershipDto> GetHorseTraderDataAsync ()
        {
            var horseTrader = await _npcGetService.GetHorseTraderByUserTypeAsync();

            var ownership = await _estateGetService.GetEstateOwnershipByUserIdAsync(horseTrader.UserId);


            return ownership;

            


        }

        public async Task<List<NpcDto>> GetNpcsWithEstatesAsync()
        {
            var users = await _npcGetService.GHetUserByNpcStatusAsync(true);

            return [.. users.Select(NpcMapper.ToNpcDto)];


        }
    }
}
