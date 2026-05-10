using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.IBreedRepos
{
    public interface IBreedGetRepository
    {
        Task<List<Breed?>> GetAllBreedsAsync();

        Task<Breed> GetBreedByIdAsync(Guid breedId);
    }
}
