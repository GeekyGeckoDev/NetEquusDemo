using Application.CompetitionApp.ICompetitionServices;
using Domain.DomainRules;
using Domain.Entities.Models.Competitions;
using Shared.Dtos.CompetitionDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.CompetitionDisciplineServices
{
    public class CompetitionManager
    { 
        private readonly ICompetitionCrudService _crudService;

        private readonly ICompetitionClassCrudService _classCrudService;

        public CompetitionManager(ICompetitionCrudService crudService)
        {
            _crudService = crudService;
        }

        public async Task<RuleResult> CreateCompetitionAsyn (CreateCompetitionDto dto)
        {
            try
            {
                var competition = new Competition
                {
                    CompetitionClassId = dto.CompetitionClassId,
                    Date = dto.Date
                };

                await _crudService.CreateCompetitionAsync(competition);

                return RuleResult.Success();
            }

            catch (Exception ex)
            {
                return RuleResult.Fail(ex.Message);
            }
        }


    }
}
