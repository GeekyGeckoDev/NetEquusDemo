using Domain.Entities.Models.Horses.Relations;
using Shared.Dtos.OwnershipDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices
{
    public interface IHorseOwnershipGetService
    {
        Task<HorseOwnership> GetOwnershipByHorseIdAsync(Guid horseId);
    }
}
