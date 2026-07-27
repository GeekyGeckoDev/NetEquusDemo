using Application.SharedApp.BreedingServices;
using Domain.Entities.Models.Horses;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.HorseDtos;
using Shared.Mappers;
using Shared.Mappers.HorseMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.FoalingRepos
{
    public class BreedListRepository : IBreedlistRepository
    {
        private readonly NetEquusDbContext _context;


        public BreedListRepository(NetEquusDbContext context)
        {
            _context = context;
        }

      

        public async Task<List<HorseInfoDto>> GetEligibleStallionsAsync (Guid damId, Guid breedId)
        {
            var stallions = await _context.Horses
            
                .Where(s => s.Sex == HorseSex.Stallion)

                .ToListAsync();

            return stallions
                 .Where(s => CalculateHorseAge.CalculateHorseAgeMapper(s) >= 3 && s.BreedId == breedId)
                .Select(HorseMapper.horseInfoDto)
                .ToList();
        }
    }
}
