using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SharedApp.BreedingServices
{
    public interface IBreedlistRepository
    {
        Task<List<HorseInfoDto>> GetEligibleStallionsAsync(Guid damId, Guid breedId);

    }
}
