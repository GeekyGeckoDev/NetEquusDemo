using Application.BoardingApp.IBoardingRepos;
using Application.BoardingApp.IBoardingServices;
using Domain.Entities.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BoardingApp.BoardingServices
{
    public class BoardíngCrudService : IBoardingCrudService
    {
        private readonly IBoardingCrudRepository _boardingCrudRepository;

        public BoardíngCrudService(IBoardingCrudRepository boardingCrudRepository)
        {
            _boardingCrudRepository = boardingCrudRepository;
        }

        public async Task CreateHorseBoardingAsync (HorseBoarding horseBoarding)
        {
            await _boardingCrudRepository.CreateHorseBoardingAsync(horseBoarding);
        }

        public async Task UpdateBoardingAsync (HorseBoarding boarding)
        {
            await _boardingCrudRepository.UpdateBoardingAsync(boarding);
        }
    }
}
