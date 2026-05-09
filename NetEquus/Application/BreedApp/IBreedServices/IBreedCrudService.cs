using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.IBreedServices
{
    public interface IBreedCrudService
    {
        Task CreateBreedAsync(Breed breed);
    }
}
