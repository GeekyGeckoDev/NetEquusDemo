using Application.EstateApp.IEstateServices.IEstateCrudServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.EconomyApp.HorseEconomyServices
{
    public class HorseEconomyService : IHorseEconomyService
    {
        private readonly IEstateGetService _estateGetservice;
        private readonly IClientEstateCrudService _clientEstateCrudService;

        public HorseEconomyService(IEstateGetService estateGetservice, IClientEstateCrudService clientEstateCrudService)
        {
            _estateGetservice = estateGetservice;
            _clientEstateCrudService = clientEstateCrudService;
        }

        public async Task DepositAsync(Guid estateId, decimal amount)
        {
            var estate = await _estateGetservice.GetEstateByIdAsync(estateId);

            estate.CurrentBalance += amount;

            await _clientEstateCrudService.UpdateEstateAsync(estate);
        }

        public async Task WithdrawAsync(Guid estateId, decimal amount)
        {
            var estate = await _estateGetservice.GetEstateByIdAsync(estateId);

            if (estate.CurrentBalance < amount)
                throw new Exception("Insufficient funds.");

            estate.CurrentBalance -= amount;

            await _clientEstateCrudService.UpdateEstateAsync(estate);
        }
    }
}
