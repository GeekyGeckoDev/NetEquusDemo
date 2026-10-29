using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.CompetitionDtos
{
    public class CreateCompetitionEntryDto
    {
        public Guid CompetitionId { get; set; }

        public Guid HorseId { get; set; }

    }
}
