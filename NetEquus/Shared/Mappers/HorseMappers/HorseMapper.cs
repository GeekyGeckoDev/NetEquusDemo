using Domain.Entities.Models.Horses;
using Domain.Enums;
using Shared.Dtos.HorseDtos;
using Shared.Mappers.BreedMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mappers.HorseMappers

{
    public class HorseMapper
    {
        public static Horse ToNewHorse (HorseGenerationDto dto)
        {
            return new Horse
            {
                HorseName = dto.HorseName,
                BirthDate = dto.Birthday,
                BreedId = dto.HorseBreed.BreedId,
                Sex = (HorseSex)dto.HorseSex,
                Height = dto.Height,
                EquinsValue = dto.EquinsValue,
                

            };


        }



        public static Horse ToHorse(HorseInfoDto dto)
        {
            return new Horse
            {
                HorseName = dto.HorseName,
                Breed = BreedMapper.ToBreed(dto.HorseBreed),
                Sex = (HorseSex)dto.HorseSex,
                Height = dto.Height,
                BirthDate = dto.Birthday,
                EquinsValue = dto.EquinsValue,


            };


        }

        public static HorseInfoDto horseInfoDto (Horse horse)
        {
            return new HorseInfoDto
            {
                HorseId = horse.GuidHorseId,
                HorseName = horse.HorseName,
                HorseBreed = BreedMapper.ToInfoDto(horse.Breed),
                HorseSex = (int)horse.Sex,
                Height = horse.Height,
                Birthday = horse.BirthDate,
                Age = CalculateHorseAge.CalculateHorseAgeMapper(horse),
                EquinsValue = horse.EquinsValue,
            };
        }
    }
}
