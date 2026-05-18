using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BoardingApp.IBoardingServices
{
    public interface IBoardingOrchestrationService
    {
        Task CreateLinkEstateToHorse(Guid EstateId, Guid HorseId);
    }
}
