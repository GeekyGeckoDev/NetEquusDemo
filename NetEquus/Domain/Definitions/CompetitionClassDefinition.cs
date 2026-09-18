using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Definitions
{
    public class CompetitionClassDefinition
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public List<CompetitionStatRequirementDefinition> Requirements { get; set; }
            = new();
    }
}
