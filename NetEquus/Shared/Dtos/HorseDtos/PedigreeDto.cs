using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.HorseDtos
{
    public class PedigreeDto
    {
        public Guid HorseId { get; set; }

        public string HorseName { get; set; }

        public string BreedName { get; set; }

        public int Height { get; set; }

        public int Age { get; set; }

        public PedigreeDto? Dam { get; set; }

        public PedigreeDto? Sire { get; set; }
    }
}
