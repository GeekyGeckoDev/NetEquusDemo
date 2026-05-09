using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.IBreedRepos
{
    public interface IBreedCrudRepository
    {
        Task CreateBreedAsync(Breed breed);

        Task UpdateBreedAsync(Breed breed);

        Task DeleteBreedAsync(Breed breed);
    }
}
