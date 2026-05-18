using Application.EstateApp.EstateDtos;
using Domain.Entities.Models.EquineEstates;
using Shared.Dtos.OwnershipDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipRepos
{
    public interface IEstateOwnershipGetRepository
    {
        Task<EstateOwnershipDto?> GetEstateOwnershipByUserId(Guid userId);
    }
}
