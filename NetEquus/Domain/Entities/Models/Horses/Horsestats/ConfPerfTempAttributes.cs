using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Models.Horses.Horsestats
{
    public class ConfPerfTempAttributes
    {
        [Key]
        public Guid CPTId { get; set; }


        public Guid PerfId { get; set; }


        public Guid ConfId { get; set; }

        [ForeignKey("PerfId")]
        public virtual PerformanceAttributes PerformanceAttributes { get; set; }

        [ForeignKey("ConfId")]
        public virtual ConformationAttributes ConformationAttributes { get; set; }

        public double Trainability { get; set; }

        public Guid GuidHorseId { get; set; }

        [ForeignKey("GuidHorseId")]

        public virtual Horse Horse { get; set; }
    }
}
