using Domain.Entities.Models.Breeds;
using Domain.Entities.Models.Horses;
using Shared.Dtos.BreedDtos;
using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.GenerateHorseInfo
{
    public class HorseHeightGenerator
    {
        public async Task<int> GenerateHorseHeightByBreed (BreedInfoDto breed)
        {
            Random rnd = new Random();
            int horseHeight = rnd.Next(breed.MinHeight, breed.MaxHeight);

            return horseHeight;
        }

        public async Task<int> GenerateFoalHeightByParents (int mareHight, int sireHeight)
        {
            Random rnd = new();

            int average = (mareHight + sireHeight) / 2;

            int variation = rnd.Next(-5, 6);

            int rareChance = rnd.Next(1, 101);

            if (rareChance <= 10)
            {
                variation = rnd.Next(-3, 4);
            }

            return average + variation;


        }
    }
}
