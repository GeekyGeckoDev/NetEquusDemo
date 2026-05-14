using Application.BreedApp.IBreedServices;
using Shared.Dtos.BreedDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.GenerateHorseInfo
{
    public class RandomHorseBreed
    {
        private readonly IBreedGetService _breedGetservice;


        public RandomHorseBreed(IBreedGetService breedGetservice)
        {
            _breedGetservice = breedGetservice;
        }

        public async Task<BreedInfoDto> RandomBreed()
        {
            var breedList = await _breedGetservice.GetAllBreedsAsync();

            if (!breedList.Any())
                throw new Exception("No breeds found");

            var rnd = new Random();

            int randomIndex = rnd.Next(0, breedList.Count);

            BreedInfoDto randomBreed = breedList[randomIndex];

            return randomBreed;
        }

    }
}
