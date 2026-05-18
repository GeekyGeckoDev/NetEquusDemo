using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.IHorseServices
{
    public interface IHorseGetService
    {
        Task<Horse?> GetHorseByIdAsync(Guid horseId);
    }
}
