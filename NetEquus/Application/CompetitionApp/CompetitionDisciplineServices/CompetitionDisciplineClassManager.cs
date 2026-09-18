using Application.CompetitionApp.ICompetitionDisciplineServices;
using Application.CompetitionApp.ICompetitionRepos;
using Application.CompetitionApp.ICompetitionServices;
using Application.UnitOfWorks;
using Domain.DomainRules;
using Domain.Entities.Models.Competitions;
using Shared.Dtos.CompetitionDtos;
using Shared.Dtos.CompetitionDtos.CompDisciplineDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.CompetitionDisciplineServices
{
    public class CompetitionDisciplineClassManager : ICompetitionDisciplineClassManager
    {
        private readonly ICompetitionDisicplineService _crudService;

        private readonly ICompetitionClassCrudService _classCrudService;

        private readonly IUnitOfWork _unitOfWork;

        public CompetitionDisciplineClassManager(ICompetitionDisicplineService crudService, ICompetitionClassCrudService classCrudService, IUnitOfWork unitOfWork)
        {
            _crudService = crudService;
            _classCrudService = classCrudService;
            _unitOfWork = unitOfWork;
        }

        public async Task<RuleResult> CreateCompetitionDisciplineWithClassAsync(
    CreateCompetitionDisciplineWithClassDto dto)
        {
            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    var discipline = new CompetitionDiscipline
                    {
                        Discipline = (Domain.Enums.Discipline)dto.Discipline
                    };

                    await _crudService.CreateCompetitionAsync(discipline);

                    var competitionClass = new CompetitionClass
                    {
                        CompetitionDisciplineId = discipline.CompetitionDisciplineId,
                        Name = dto.ClassName,
                        Level = dto.Level,

                        StatRequirements = dto.Requirements
                            .Select(r => new CompetitionStatRequirement
                            {
                                Stat = (Domain.Enums.GenerationStat)r.Stat,
                                Weight = r.Weight
                            })
                            .ToList()
                    };

                    await _classCrudService.CreateCompetitionClassAsync(competitionClass);
                });

                return RuleResult.Success();
            }
            catch (Exception ex)
            {
                return RuleResult.Fail($"Competition discipline creation failed; {ex.Message}");
            }
        }

   
    }
}
