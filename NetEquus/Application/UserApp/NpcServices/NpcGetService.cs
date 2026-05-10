using Application.UserApp.IUserRepos;
using Domain.Entities.Models.Users;
using Shared.Dtos.NpcDtos;
using Shared.Mappers.NpcMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.NpcServices
{
    public class NpcGetService : INpcGetService
    {
        private readonly IUserGetRepository _userGetRepository;

        public NpcGetService(IUserGetRepository userGetRepository)
        {
            _userGetRepository = userGetRepository;
        }

        public async Task<List<User>> GHetUserByNpcStatusAsync (bool isNpc)
        {
            return await _userGetRepository.GetUserByNpcStatusAsync(isNpc);

        }
    }
}
