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

        public string HorseSex { get; set; }

        public int Height { get; set; }


        public int Age = 4;

        public DateOnly Birthdate = DateOnly.FromDateTime(DateTime.Now);
    }
}
