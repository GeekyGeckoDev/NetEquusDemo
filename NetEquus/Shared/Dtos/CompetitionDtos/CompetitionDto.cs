using Shared.Dtos.CompetitionDtos.CompDisciplineDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.CompetitionDtos
{
    public class CreateCompetitionDto
    {
        public Guid CompetitionClassId { get; set; }

        public DateTime Date { get; set; }
    }

    public class CompetitionDto
    {
        public Guid Id { get; set; }

        public CompetitionClassDto CompetitionClassDto { get; set; }

        public DateTime Date { get; set; }
    }
}
