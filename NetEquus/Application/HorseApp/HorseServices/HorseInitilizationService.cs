using Application.HorseApp.GenerateHorseInfo;
using Application.HorseApp.IHorseServices;
using Application.HorseApp.UpdateHorse;
using Domain.Entities.Models.Breeds;
using Domain.Entities.Models.Horses;
using Domain.Enums;
using Shared.Dtos.HorseDtos;
using Shared.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseServices
{
    public class HorseInitilizationService : IHorseInitilizationService
    {
        private readonly RandomHorseName _randomHorseName;
        private readonly HorseGenderGenerator _randomGenderGenerator;
        private readonly RandomHorseBreed _randomHorseBreed;
        private readonly HorseHeightGenerator _randomHorseHeightGenerator;


        public HorseInitilizationService(RandomHorseName randomHorseName, HorseGenderGenerator horseGenderGenerator, RandomHorseBreed randomHorseBreed, HorseHeightGenerator randomHorseHeightGenerator)
        {
            _randomHorseName = randomHorseName;
            _randomGenderGenerator = horseGenderGenerator;
            _randomHorseBreed = randomHorseBreed;
            _randomHorseHeightGenerator = randomHorseHeightGenerator;

        }
        public async Task<HorseGenerationDto> HorseGenerationInitilizationAsync()
        {
            var sex = _randomGenderGenerator.RandomSex();

            var name = await _randomHorseName.HorseNameRandomizer((HorseSex)sex);

            var birthdate = CalculateHorseAge.CalculateBirthdate(4);

            var breed = await _randomHorseBreed.RandomBreed();

            var height = await _randomHorseHeightGenerator.GenerateHorseHeightByBreed(breed);


            var horseDto = new HorseGenerationDto
            {
                HorseName = name,

                Birthday = birthdate,

                HorseSex = (int)sex,

                HorseBreed = breed,

                Height = height,

                EquinsValue = 25000


            };

            return horseDto;
        }

        public async Task<Horse> FoalGenerationInitilizationAsync (Horse dam, Horse sire)
        {
            var sex = _randomGenderGenerator.RandomSex();
            var name = await _randomHorseName.HorseNameRandomizer (sex);
            var birthdate = CalculateHorseAge.CalculateBirthdate(0);
            var height = await _randomHorseHeightGenerator.GenerateFoalHeightByParents(dam.Height, sire.Height);
            var value = ValueCalculator.CalculateFoalValue(dam.EquinsValue, sire.EquinsValue);


            var foal = new Horse
            {
                HorseName = name,

                BirthDate = birthdate,

                Sex = sex,

                Breed = dam.Breed,

                Height = height,

                EquinsValue = value,

                IsFoal = true


            };

            return foal;
        }
    }
}
