using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SharedApp.BreedingServices
{
    public interface IBreedListService
    {
        Task<List<HorseInfoDto>> GetEligibleBreedingMaresAsync(Guid userId);

        Task<List<HorseInfoDto>> GetEligibleStallionsAsync(Guid damId);

    }
}
