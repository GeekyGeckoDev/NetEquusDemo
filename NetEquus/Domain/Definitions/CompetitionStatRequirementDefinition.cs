using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Definitions
{
    public class CompetitionStatRequirementDefinition
    {
        public GenerationStat Stat { get; set; }

        public double Weight { get; set; }
    }
}
