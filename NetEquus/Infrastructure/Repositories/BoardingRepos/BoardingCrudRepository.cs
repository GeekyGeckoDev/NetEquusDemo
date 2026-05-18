using Application.BoardingApp.IBoardingRepos;
using Domain.Entities.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.BoardingRepos
{
    public class BoardingCrudRepository : IBoardingCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public BoardingCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateHorseBoardingAsync (HorseBoarding horseBoarding)
        {
            await _context.HorseBoardings.AddAsync (horseBoarding);
        }
    }
}
