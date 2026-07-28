using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices
{
    public interface IHorseOwnershipOrchestrationService
    {
        Task CreateLinkUserToHorseAsync(Guid userId, Guid horseId);
    }
}
