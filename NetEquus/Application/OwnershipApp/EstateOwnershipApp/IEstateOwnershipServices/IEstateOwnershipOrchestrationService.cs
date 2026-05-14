using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices
{
    public interface IEstateOwnershipOrchestrationService
    {
        Task LinkUserToEstateAsync(Guid userId, Guid estateId, bool isPrimaryOwner);
    }
}
