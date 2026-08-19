using Domain.Entities.Models.Horses.Horsestats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Models.Competitions
{
    public class CompetitionStatRequirement
    {
        public Guid CompetitionStatRequirementId { get; set; }

        public Guid CompetitionDisciplineId { get; set; }

        public CompetitionDiscipline CompetitionDiscipline { get; set; }

        public PerformanceAttributes Stat { get; set; }

        public double Weight { get; set; }

    }
}
