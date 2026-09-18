using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Models.Competitions
{
    public class CompetitionDiscipline
    {
        [Key]
        public Guid CompetitionDisciplineId { get; set; }

        public Discipline Discipline { get; set; }

        public ICollection<CompetitionClass> Classes { get; set; }
            = new List<CompetitionClass>();
    }
}
