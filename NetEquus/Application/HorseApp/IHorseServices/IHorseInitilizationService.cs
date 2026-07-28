using Domain.Entities.Models.Horses;
using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.IHorseServices
{
    public interface IHorseInitilizationService
    {
        Task<HorseGenerationDto> HorseGenerationInitilizationAsync();

        Task<Horse> FoalGenerationInitilizationAsync(Foaling foaling);
    }
}
