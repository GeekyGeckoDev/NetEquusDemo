using Shared.Dtos.BreedDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.HorseDtos
{
    public class HorseGenerationDto
    {
        public string HorseName { get; set; }

        public BreedInfoDto HorseBreed { get; set; }

        public int HorseSex { get; set; }

        public int Height { get; set; }


        public int Age = 4;

    }
}
