using Domain.Entities.Models.Breeds;
using Domain.Entities.Models.Horses;
using Shared.Dtos.BreedDtos;
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
    }
}
