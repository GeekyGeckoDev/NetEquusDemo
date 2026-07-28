using Application.BoardingApp.IBoardingServices;
using Application.FoalingApp.IFoalingServices;
using Application.HorseApp.IHorseServices;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CycleApp.DailyChecks
{
    public class FoalingCheckService : IFoalingCheckService
    {
        private readonly IFoalingGetService _foalingGetservice;
        private readonly IHorseBirthManager _horseBirthManager;


        public FoalingCheckService(IFoalingGetService foalingGetService, IHorseBirthManager horseBirthManager)
        {
            _foalingGetservice = foalingGetService;
            _horseBirthManager = horseBirthManager;
          
        }

        public async Task ProcessDueFoalingsAsync (Guid UserId)
        {

            var dueFoalings = await _foalingGetservice.GetDueFoalingsAsync(UserId);

            foreach(var foaling in dueFoalings)
            {
                await _horseBirthManager.CreateFoalFromFoaling(foaling);
            }
        }
    }
}
