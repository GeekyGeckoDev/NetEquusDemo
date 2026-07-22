using System;
using System.Collections.Generic;
using System.Text;

namespace Application.EconomyApp.HorseEconomyServices
{
    public interface IHorseEconomyService
    {
        Task DepositAsync(Guid estateId, decimal amount);

        Task WithdrawAsync(Guid estateId, decimal amount);
    }
}
