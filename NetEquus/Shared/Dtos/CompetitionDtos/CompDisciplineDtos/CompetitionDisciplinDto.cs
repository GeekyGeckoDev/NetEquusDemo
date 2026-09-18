using Shared.Enums;
using System;
using System.Collections.Generic;

namespace Shared.Dtos.CompetitionDtos.CompDisciplineDtos
{
    public class CreateCompetitionDisciplineWithClassDto
    {
        public Discipline Discipline { get; set; }

        public string ClassName { get; set; }

        public int Level { get; set; }

        public List<CreateCompetitionStatRequirementDto> Requirements { get; set; }
            = new();
    }

    public class CreateCompetitionClassDto
    {
        public Guid CompetitionDisciplineId { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public List<CreateCompetitionStatRequirementDto> Requirements { get; set; }
            = new();
    }
}