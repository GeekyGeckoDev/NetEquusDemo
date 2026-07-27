using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.NpcServices
{
    public interface INpcGetService
    {
        Task<List<User>> GHetUserByNpcStatusAsync(bool isNpc);

        Task<User> GetHorseTraderByUserTypeAsync();
    }
}
