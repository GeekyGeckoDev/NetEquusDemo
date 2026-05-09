using Application.BreedApp.IBreedRepos;
using Application.BreedApp.IBreedServices;
using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedServices
{
    public class BreedCrudService : IBreedCrudService
    {
        private readonly IBreedCrudRepository _breedCrudrepository;

        public BreedCrudService(IBreedCrudRepository breedCrudRepository)
        {
            _breedCrudrepository = breedCrudRepository;
        }

        public async Task CreateBreedAsync (Breed breed)
        {
            await _breedCrudrepository.CreateBreedAsync(breed);
        }

        
    }
}
