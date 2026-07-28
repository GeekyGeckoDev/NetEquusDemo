using Domain.DomainRules.Helpers;
using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.DomainRules.BreedingRules.BreedingDelegateCheckAll;


namespace Domain.DomainRules.BreedingRules
{
    public static class BreedingRules
    {
      
            public static HorsePairRule NotSameHorse = (dam, sire) =>
                dam.GuidHorseId != sire.GuidHorseId ? RuleResult.Success() : RuleResult.Fail("Horse cannot breed with itself.");

            public static HorsePairRule OppositeSex = (dam, sire) =>
                dam.Sex != sire.Sex ? RuleResult.Success() : RuleResult.Fail("Breeding requires opposite sexes.");


        public static HorsePairRule Mature = (dam, sire) =>
                CalculateHorseAge.CalculateHorseAgeMapper(dam) >= 3 &&
            CalculateHorseAge.CalculateHorseAgeMapper(sire) >= 3
            ? RuleResult.Success()
            : RuleResult.Fail("Both horses must be at least 3 years old.");

        public static HorseRule OnCoolDown = (horse) =>
        horse.Sex == 0 && horse.BreedingCoolDown < DateOnly.FromDateTime(DateTime.UtcNow)
        ? RuleResult.Success() : RuleResult.Fail("Both horses must be at least 3 years old.");
    }
}
