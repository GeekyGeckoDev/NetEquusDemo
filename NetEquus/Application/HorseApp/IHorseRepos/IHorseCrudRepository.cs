using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.IHorseRepos
{
    public interface IHorseCrudRepository
    {
        Task CreateHorseAsync(Horse horse);

        Task UpdateHorseAsync(Horse horse);

        Task DeleteHorseAsync(Horse horse);
    }
}
