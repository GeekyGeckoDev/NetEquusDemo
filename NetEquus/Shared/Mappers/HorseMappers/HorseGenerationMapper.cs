using Domain.Entities.Models.Horses;
using Domain.Enums;
using Shared.Dtos.HorseDtos;
using Shared.Mappers.BreedMappers;
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


        public static int CalculateHorseAge(Horse horse)
        {
            DateOnly birthdate = horse.BirthDate;

            int cycleLength = 30;

            int daysAlive =
                DateOnly.FromDateTime(DateTime.Today).DayNumber
                - birthdate.DayNumber;

            int cyclesPassed = daysAlive / cycleLength;

            return cyclesPassed;
        }

        public static Horse ToHorse(HorseInfoDto dto)
        {
            return new Horse
            {
                HorseName = dto.HorseName,
                Breed = BreedMapper.ToBreed(dto.HorseBreed),
                Sex = (HorseSex)dto.HorseSex,
                Height = dto.Height,
                BirthDate = dto.Birthday


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
                Age = CalculateHorseAge(horse)
            };
        }
    }
}
