using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Models.Breeds
{
    public class BreedGenerationStats
    {
        public Guid BreedGenerationStatsId { get; set; }

        public Guid BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        public ICollection<BreedMinMaxStat> GenerationStats { get; set; } = [];

        public BreedGenerationStats(Guid breedGenerationStatsId, Guid breedId)
        {
            BreedGenerationStatsId = Guid.NewGuid();
            BreedId = breedId;
        }

        public BreedGenerationStats() { }
    }
}
