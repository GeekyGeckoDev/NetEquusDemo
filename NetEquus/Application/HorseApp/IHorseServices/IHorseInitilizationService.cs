using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.IHorseServices
{
    public interface IHorseInitilizationService
    {
        Task<HorseGenerationDto> HorseGenerationInitilizationAsync();
    }
}
