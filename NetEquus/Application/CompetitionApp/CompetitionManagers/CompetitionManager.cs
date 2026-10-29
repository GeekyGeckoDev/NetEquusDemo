using Application.CompetitionApp.ICompetitionManagers;
using Application.CompetitionApp.ICompetitionServices;
using Application.UnitOfWorks;
using Domain.DomainRules;
using Domain.Entities.Models.Competitions;
using Shared.Dtos.CompetitionDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.CompetitionDisciplineServices
{
    public class CompetitionManager : ICompetitionManager
    {
        private readonly ICompetitionCrudService _crudService;

        private readonly ICompetitionEntryCrudService _entryCrudService;
        private readonly IUnitOfWork _unitOfWork;

        public CompetitionManager(ICompetitionCrudService crudService, IUnitOfWork unitOfWork, ICompetitionEntryCrudService entryCrudService)
        {
            _crudService = crudService;
            _unitOfWork = unitOfWork;
            _entryCrudService = entryCrudService;
        }

        public async Task<RuleResult> CreateCompetitionAsync(CreateCompetitionDto dto)
        {
            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    var competition = new Competition
                    {
                        CompetitionClassId = dto.CompetitionClassId,
                        Date = dto.Date
                    };

                    await _crudService.CreateCompetitionAsync(competition);
                });

                return RuleResult.Success();

            }

            catch (Exception ex)
            {
                return RuleResult.Fail($"Competition discipline creation failed; {ex.Message}");



            }
        }

        public async Task<RuleResult> CreateCompetitionEntryAsync(
        CreateCompetitionEntryDto dto)
        {
            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    var competition = await _crudService
                        .getCompetitionById(dto.CompetitionId);

                    if (competition == null)
                    {
                        throw new Exception("Competition not found.");
                    }

                    var competitionEntry = new CompetitionEntry
                    {
                        CompetitionId = dto.CompetitionId,
                        GuidHorseId = dto.HorseId
                    };

                    await _entryCrudService
                        .CreateCompetitionEntryAsync(competitionEntry);
                });

                return RuleResult.Success();
            }
            catch (Exception ex)
            {
                return RuleResult.Fail(
                    $"Competition entry creation failed; {ex.Message}");
            }
        }

        public async Task endCompetitionAddResults (Guid competitionId)
        {

        }
    }
}