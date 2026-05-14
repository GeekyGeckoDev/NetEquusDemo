using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipRepos
{
    public interface IEstateOwnershipValidationRepository
    {
        Task<bool> UserAlreadyOwnsAnyEstateAsync(Guid userId);
    }
}
