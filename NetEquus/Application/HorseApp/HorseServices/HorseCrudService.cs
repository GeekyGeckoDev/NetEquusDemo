using Application.HorseApp.IHorseRepos;
using Application.HorseApp.IHorseServices;
using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseServices
{
    public class HorseCrudService : IHorseCrudService
    {
        private readonly IHorseCrudRepository _horseCrudrepository;

        public HorseCrudService(IHorseCrudRepository horseCrudRepository)
        {
            _horseCrudrepository = horseCrudRepository;
        }

        public async Task CreateHorseAsync(Horse horse)
        {
            await  _horseCrudrepository.CreateHorseAsync(horse);
        }


    }
}
