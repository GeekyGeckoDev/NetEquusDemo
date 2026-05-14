using Domain.Entities.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipRepos
{
    public interface IHorseOwnershipCrudRepository
    {
        Task CreateHorseOwnershipAsync(HorseOwnership horseOwnership);

        Task UpdateHorseOwnershipAsync(HorseOwnership horseOwnership);

        Task DeleteHorseOwnerShipAsync(HorseOwnership horseOwnership);

    }
}
