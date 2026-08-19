using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Models.Breeds
{
  public class BreedMinMaxStat
{
     [Key]
    public Guid BreedMinMaxStatId { get; set; }

    public Guid BreedGenerationStatsId { get; set; }
    public BreedGenerationStats BreedStats { get; set; }

    public GenerationStat Attribute { get; set; }

    public double Min { get; set; }

    public double Max { get; set; }

        public BreedMinMaxStat(Guid breedMinMaxStat, Guid breedGenerationStatsId, GenerationStat attribute) 
        {
            BreedMinMaxStatId = Guid.NewGuid();
            BreedGenerationStatsId = breedGenerationStatsId;
            Attribute = attribute;
        }
        public BreedMinMaxStat() { }
}
}
