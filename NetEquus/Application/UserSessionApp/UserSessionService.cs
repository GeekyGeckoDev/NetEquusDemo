using Application.EstateApp.IEstateServices.IEstateCrudServices;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices;
using Application.UserApp.IUserServices.IUserCrudServices;
using Domain.Entities.Models.EquineEstates;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserSessionApp
{
    public class UserSessionService : IUserSessionService
    {
        private readonly IUserGetService _userGetService;
        private readonly IEstateGetService _estateGetService;
        private readonly IEstateOwnershipGetService _estateOwnershipGetService;

        public UserSessionService(IUserGetService userGetService, IEstateGetService estateGetService, IEstateOwnershipGetService estateOwnershipGetService)
        {
            _userGetService = userGetService;
            _estateGetService = estateGetService;
            _estateOwnershipGetService = estateOwnershipGetService;
        }

        public async Task<UserMeDto?> BuildUserSessionAsync(Guid userId)
        {
            var user = await _userGetService.GetUserByIdAsync(userId);
            if (user == null) return null;

            var ownership = await _estateOwnershipGetService.GetEstateOwnershipByUserIdAsync(userId);

            EquineEstate? estate = null;

            Guid estateId = (Guid)ownership.EquineEstateId;

            if (ownership != null)
                estate = await _estateGetService.GetEstateByIdAsync(estateId);

            return new UserMeDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                EstateId = estate?.EstateId,
                EstateName = estate?.EstateName
            };
        }
    }
}
