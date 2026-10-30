using Application.CompetitionApp.ICompetitionServices;
using Application.HorseApp.IHorseServices;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks; // add this for Task

namespace Application.CompetitionApp.CalculateCompScores
{
    public class CalculateCompetitionScores
    {

        private readonly ICompetitionStatRequirementService _requirementService;

        private readonly IHorseGetService _horseGetService;

        public CalculateCompetitionScores(ICompetitionStatRequirementService requirementService, IHorseGetService horseGetService)
        {
            _requirementService = requirementService;
            _horseGetService = horseGetService;
        }
        //public async Task<List<CompetitionResult>> CalculateCompetitionScore(Competition comp)
        //{
        //    var statRequirements =
        //        await _requirementService
        //            .GetCompetitionStatRequirementsAsync(comp.Class);

        //    var results = new List<CompetitionResult>();

        //    foreach (var entry in comp.CompetitionEntries)
        //    {
        //        var horse = entry.Horse;

        //        double weightedScore = 0;

        //        foreach (var requirement in statRequirements)
        //        {
        //            var performanceAttribute =
        //                horse.ConfPerfTempAttributes
        //                    .PerformanceAttributes
        //                    .FirstOrDefault(x => x.Stat == requirement.Stat);

        //            if (performanceAttribute == null)
        //                continue;

        //            weightedScore +=
        //                performanceAttribute.Value * requirement.Weight;
        //        }

        //        // weightedScore er nu hestens samlede score
        //    }

        //    return results;
        //}
    }
}