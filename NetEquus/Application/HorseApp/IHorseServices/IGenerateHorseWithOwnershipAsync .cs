using Domain.DomainRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.IHorseServices
{
    public interface IHorseOrchestrationService
    {
        Task<RuleResult> GenerateHorseWithOwnershipAsync();
    }
}
