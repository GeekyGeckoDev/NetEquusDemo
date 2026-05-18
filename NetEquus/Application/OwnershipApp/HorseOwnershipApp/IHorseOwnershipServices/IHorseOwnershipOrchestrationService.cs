using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices
{
    public interface IHorseOwnershipOrchestrationService
    {
        Task CreateLinkUserToHorse(Guid userId, Guid horseId);
    }
}
