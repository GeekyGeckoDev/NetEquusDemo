using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.HorseDtos
{
    public class TransferHorseDto
    {
        public Guid HorseId { get; set; }

        public Guid NewEstateId { get; set; }
    }
}
