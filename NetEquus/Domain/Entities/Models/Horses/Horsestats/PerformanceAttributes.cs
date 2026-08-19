using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Models.Horses.Horsestats
{
    public class PerformanceAttributes
    {
        [Key]
        public Guid PerfId { get; set; }

        public double Gaits { get; set; }

        public double Scope { get; set; }

        public double Speed { get; set; }

        public double Agility { get; set; }

        public double Endurance { get; set; }

        public double Stride { get; set; }

        public double Trainability { get; set; }

    }
}
