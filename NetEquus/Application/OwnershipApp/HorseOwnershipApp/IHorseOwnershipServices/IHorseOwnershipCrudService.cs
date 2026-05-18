using Domain.Entities.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices
{
    public interface IHorseOwnershipCrudService
    {
        Task CreateHorseOwnershipAsync(HorseOwnership horseOwnership);

        Task UpdateHorseOwnershipAsync(HorseOwnership horseOwnership);
    }
}
