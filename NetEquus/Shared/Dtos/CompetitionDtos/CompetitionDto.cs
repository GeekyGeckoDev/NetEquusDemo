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
}
