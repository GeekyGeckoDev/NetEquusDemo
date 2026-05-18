
using Domain.Entities.Models.EquineEstates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices
{
    public interface IEstateOwnershipCrudService
    {
        Task CreateEstateOwnershipAsync(EstateOwnership estateOwnership);

        Task UpdateEstateOwnershipAsync(EstateOwnership estateOwnership);

        Task DeleteOwnershipAsync(EstateOwnership estateOwnership);

    }
}
