using Application.UnitOfWorks;
using Application.UserApp.IUserServices;
using Domain.DomainRules;
using Shared.Dtos.NpcDtos;
using Shared.Mappers.NpcMappers;
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
        public NpcManagerService(INpcInitilizationService npcInitilizationService, IUnitOfWork unitOfWork, IUserCrudService userCrudService, INpcGetService npcGetService)
        {
            _initilizationService = npcInitilizationService;
            _unitOfWork = unitOfWork;
            _userCrudService = userCrudService;
            _npcGetService = npcGetService;
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
    }
}
