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

        public DateOnly Birthday { get; set; }

        public int HorseSex { get; set; }

        public int Height { get; set; }



    }

    public class HorseInfoDto
    {

        public Guid HorseId { get; set; }
        public string HorseName { get; set; }

        public BreedInfoDto HorseBreed { get; set; }

        public int HorseSex { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public DateOnly Birthday { get; set; }


    }
}