using Domain.Entities.Models.EquineEstates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SharedApp.IOwnershipRepos
{
    public interface IEstateOwnersipCrudRepository
    {
        Task CreateEstateOwnershipAsync(EstateOwnership estateOwnership);

        Task UpdateEstateOwnershipAsync(EstateOwnership estateOwnership);

        Task DeleteEstateOwnershipAsync(EstateOwnership estateOwnership);

    }
}
