using Application.BreedApp.IBreedRepos;
using Application.BreedApp.IBreedServices;
using Domain.Entities.Models.Breeds;
using Shared.Dtos.BreedDtos;
using Shared.Mappers.BreedMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedServices
{
    public class BreedGetService : IBreedGetService
    {
        private readonly IBreedGetRepository _breedGetrepository;

        public BreedGetService(IBreedGetRepository breedGetrepository)
        {
            _breedGetrepository = breedGetrepository;
        }

        public async Task<List<BreedInfoDto>> GetAllBreedsAsync()
        {
            var breeds = await _breedGetrepository.GetAllBreedsAsync();
            return breeds.Select(BreedMapper.ToInfoDto).ToList();
        }

        public async Task<Breed?> GetBreedByIdAsync(Guid breedId)
        {
            return await _breedGetrepository.GetBreedByIdAsync(breedId);
        }

    }


}
