using Domain.Entities.Models.Horses;
using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.IHorseServices
{
    public interface IHorseGetService
    {
        Task<Horse?> GetHorseByIdAsync(Guid horseId);

        Task<List<HorseInfoDto>> GetMaresAsync();

        Task<List<HorseInfoDto>> GetStallionsAsync();

        Task<PedigreeDto?> BuildPedigreeAsync(Guid horseId, int generations);


    }
}
