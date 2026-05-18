using Application.HorseApp.IHorseRepos;
using Application.HorseApp.IHorseServices;
using Domain.Entities.Models.Horses;
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
    }
}
