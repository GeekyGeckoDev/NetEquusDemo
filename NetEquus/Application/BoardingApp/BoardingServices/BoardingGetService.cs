using Application.BoardingApp.IBoardingRepos;
using Application.BoardingApp.IBoardingServices;
using Domain.Entities.Models.Horses.Relations;
using Shared.Dtos.BoardingDtos;
using Shared.Mappers.BoardingMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BoardingApp.BoardingServices
{
    public class BoardingGetService : IBoardingGetService
    {
        private readonly IBoardingGetRepository _repository;

        public BoardingGetService (IBoardingGetRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BoardingDto>> GetBoardingByEstateIdAsync(Guid estateId)
        {
            return await _repository.GetBoardingsByEstateId(estateId);

        }

        public async Task<HorseBoarding> GetBoardingByHorseIdAsync (Guid horseId)
        {
            return await _repository.GetBoardingByHorseId(horseId);
            
            

        }
    }
}
