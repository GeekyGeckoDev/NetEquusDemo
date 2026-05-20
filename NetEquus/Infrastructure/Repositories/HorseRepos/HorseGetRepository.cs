using Application.HorseApp.IHorseRepos;
using Domain.Entities.Models.Horses;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.HorseDtos;
using Shared.Mappers.HorseMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.HorseRepos
{
    public class HorseGetRepository : IHorseGetRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseGetRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<Horse?> GetHorseByIdAsync (Guid horseId)
        {
            return await _context.Horses.Include(h => h.Breed).FirstOrDefaultAsync(h => h.GuidHorseId == horseId);
        }

        public async Task<List<HorseInfoDto>> GetHorsesBySexAsync(int sex)
        {
            var list = await _context.Horses
                .Where(h => h.Sex == (HorseSex)sex)
                .Include(h => h.Breed)
                .ToListAsync();

            return list
                .Select(HorseGenerationMapper.horseInfoDto)
                .ToList();
        }
    }
}
