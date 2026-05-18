using Domain.Entities.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipRepos
{
    public interface IHorseOwnershipGetRepository
    {
        Task<HorseOwnership> GetOwnershipByHorseId(Guid horseId);
    }
}
