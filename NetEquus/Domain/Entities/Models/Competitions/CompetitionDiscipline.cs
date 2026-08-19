using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Models.Competitions
{
    public class CompetitionDiscipline
    {
        public Guid CompetitionDisciplineId { get; set; }

        public Discipline Discipline { get; set; }

        public ICollection<CompetitionStatRequirment> StatRequirements { get; set; }
            = new List<CompetitionStatRequirment>();
    }
}
