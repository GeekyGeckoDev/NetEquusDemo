using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Models.Competitions
{
    public class Competition
    {
        [Key]
        public Guid CompetitionId { get; set; }

        [ForeignKey(nameof(CompetitionDisciplineId))]
        public virtual CompetitionDiscipline Discipline { get; set; }

        public Guid CompetitionDisciplineId { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<CompetitionEntry> CompetitionEntries { get; set; } = new List<CompetitionEntry>();

        public virtual ICollection<CompetitionResult> CompetitionResults { get; set; } = new List<CompetitionResult>();
    }
}
