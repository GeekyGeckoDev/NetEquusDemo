using Application.EstateApp.EstateDtos;
using Domain.Entities.Models.EquineEstates;
using Shared.Dtos.OwnershipDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices
{
    public interface IEstateOwnershipGetService
    {
        Task<EstateOwnershipDto?> GetEstateOwnershipByUserIdAsync(Guid userId);
    }
}
