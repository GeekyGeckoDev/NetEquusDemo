using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.CompetitionDtos
{
    public class CreateCompetitionDisciplineDto
    {
        public Discipline Discipline { get; set; }

        public List<CreateCompetitionStatRequirementDto> Requirements { get; set; }
            = new();
    }

    public class CreateCompetitionStatRequirementDto
    {
        public GenerationStat Stat { get; set; }

        public double Weight { get; set; }
    }
}
