using Domain.Entities.Models.Horses.Horsestats;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Models.Competitions
{
    public class CompetitionStatRequirement
    {
        [Key]
        public Guid CompetitionStatRequirementId { get; set; }

        public Guid CompetitionClassId { get; set; }

        public CompetitionClass CompetitionClass { get; set; }

        public GenerationStat Stat { get; set; }

        public double Weight { get; set; }
    }
}
