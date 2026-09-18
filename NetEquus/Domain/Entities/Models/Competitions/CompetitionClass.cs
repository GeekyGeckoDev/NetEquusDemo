using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Models.Competitions
{
    public class CompetitionClass
    {
        [Key]
        public Guid CompetitionClassId { get; set; }

        public Guid CompetitionDisciplineId { get; set; }

        public CompetitionDiscipline CompetitionDiscipline { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public ICollection<CompetitionStatRequirement> StatRequirements { get; set; }
            = new List<CompetitionStatRequirement>();
    }

}
