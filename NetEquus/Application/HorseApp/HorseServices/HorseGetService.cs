using Application.HorseApp.IHorseRepos;
using Application.HorseApp.IHorseServices;
using Domain.Entities.Models.Horses;
using Domain.Enums;
using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseServices
{
    public class HorseGetService : IHorseGetService
    {
        private readonly IHorseGetRepository _repository;

        public HorseGetService(IHorseGetRepository repository)
        {
            _repository = repository;
        }

        public async Task<Horse?> GetHorseByIdAsync (Guid horseId)
        {
            return await _repository.GetHorseByIdAsync (horseId);
        }

        public async Task<List<HorseInfoDto>> GetMaresAsync()
        {
            return await _repository.GetHorsesBySexAsync(0);
        }

        public async Task<List<HorseInfoDto>> GetStallionsAsync()
        {
            return await _repository.GetHorsesBySexAsync(1);
        }
    }
}
