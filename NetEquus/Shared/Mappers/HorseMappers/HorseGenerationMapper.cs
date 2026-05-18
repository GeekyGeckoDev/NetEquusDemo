using Domain.Entities.Models.Horses;
using Domain.Enums;
using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mappers.HorseMappers
{
    public class HorseGenerationMapper
    {
        public static Horse ToNewHorse (HorseGenerationDto dto)
        {
            return new Horse
            {
                HorseName = dto.HorseName,
                BreedId = dto.HorseBreed.BreedId,
                Sex = (HorseSex)dto.HorseSex,
                Height = dto.Height
                

            };
        }
    }
}
