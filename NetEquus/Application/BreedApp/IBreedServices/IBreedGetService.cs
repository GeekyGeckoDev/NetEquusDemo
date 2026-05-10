using Domain.Entities.Models.Breeds;
using Shared.Dtos.BreedDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.IBreedServices
{
    public interface IBreedGetService
    {
        Task<List<BreedInfoDto>> GetAllBreedsAsync();


        Task<Breed?> GetBreedByIdAsync(Guid breedId);

    }
}
