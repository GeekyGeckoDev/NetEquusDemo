using Shared.Dtos.BreedDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.IBreedServices
{
    public interface IBreedInitilizationService
    {
        Task BreedInitilizationAsync(BreedDto dto);
    }
}
