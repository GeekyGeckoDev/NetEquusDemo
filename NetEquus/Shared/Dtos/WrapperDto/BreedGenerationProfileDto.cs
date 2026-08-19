using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.WrapperDto
{
    public class BreedGenerationProfileDto
    {
        public Guid BreedId { get; set; }

        public List<BreedGenerationStatDto> Stats { get; set; } = new();
    }

    public class BreedGenerationStatDto
    {
        public GenerationStat GenStat { get; set; }

        public double Min { get; set; }

        public double Max { get; set; }
    }
}
