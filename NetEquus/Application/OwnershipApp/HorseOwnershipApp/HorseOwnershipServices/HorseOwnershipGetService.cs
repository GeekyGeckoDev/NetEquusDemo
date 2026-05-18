using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipRepos;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using Domain.Entities.Models.Horses.Relations;
using Shared.Dtos.OwnershipDtos;
using Shared.Mappers.OwnershipMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OwnershipApp.HorseOwnershipApp.HorseOwnershipServices
{
    public class HorseOwnershipGetService : IHorseOwnershipGetService

    {
        private readonly IHorseOwnershipGetRepository _repository;

        public HorseOwnershipGetService(IHorseOwnershipGetRepository repository)
        {
            _repository = repository;
        }

        public async Task<HorseOwnership> GetOwnershipByHorseIdAsync (Guid horseId)
        {
            return await _repository.GetOwnershipByHorseId (horseId);

            
        }
    }
}
