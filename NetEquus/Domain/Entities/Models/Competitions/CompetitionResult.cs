using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Models.Competitions
{
    public class CompetitionResult
    {
        [Key]
        public Guid ResultId { get; set; }

        public Guid CompetitionId { get; set; }

        public Guid GuidHorseId { get; set; }

        public int Placement { get; set; }

        public int PlacementPrice { get; set; }

        [ForeignKey("CompetitionId")]

        public virtual Competition Competition { get; set; }

        [ForeignKey("GuidHorseId")]

        public virtual Horse Horse { get; set; }
    }
}
