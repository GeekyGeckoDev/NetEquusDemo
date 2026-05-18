using Application.EstateApp.EstateDtos;
using Domain.DomainRules;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EstateApp.IEstateServices.IEstateOrchestrationServices
{
    public interface IEstateOrchestrationService
    {
        Task<RuleResult> CreateEstateWithOwnership(Guid userId, EstateCreationDto estateCreationDto);

        Task<EstateDto> GetConvertEstateAsync(Guid estateId);
    }
}
