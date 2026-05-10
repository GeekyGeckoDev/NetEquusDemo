using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.BreedDtos
{
    public class BreedDto
    {
        public string BreedName { get; set; }

        public string BreedAbbreviation { get; set; }

        public int MinHeight { get; set; }

        public int MaxHeight { get; set; }
    }

    public class BreedInfoDto
    {
        public Guid BreedId { get; set; }
        public string BreedName { get; set; }

        public string BreedAbbreviation { get; set; }

        public int MinHeight { get; set; }

        public int MaxHeight { get; set; }
    }
}
