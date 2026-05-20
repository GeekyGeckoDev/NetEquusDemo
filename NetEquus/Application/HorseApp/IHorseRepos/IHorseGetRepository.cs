using Domain.Entities.Models.Horses;
using Domain.Enums;
using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.IHorseRepos
{
    public interface IHorseGetRepository
    {
        Task<Horse?> GetHorseByIdAsync(Guid horseId);

        Task<List<HorseInfoDto>> GetHorsesBySexAsync(int sex);

        Task<PedigreeDto?> BuildPedigreeAsync(Guid horseId, int generations);
    }
}
