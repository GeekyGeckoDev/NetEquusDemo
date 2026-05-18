using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.IHorseRepos
{
    public interface IHorseGetRepository
    {
        Task<Horse?> GetHorseByIdAsync(Guid horseId);
    }
}
