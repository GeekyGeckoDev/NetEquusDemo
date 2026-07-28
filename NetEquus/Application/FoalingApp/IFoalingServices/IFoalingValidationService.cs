using Domain.DomainRules;
using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FoalingApp.IFoalingServices
{
    public interface IFoalingValidationService
    {
        Task<RuleResult> CheckFoalingRules(Horse dam, Horse sire);
    }
}
