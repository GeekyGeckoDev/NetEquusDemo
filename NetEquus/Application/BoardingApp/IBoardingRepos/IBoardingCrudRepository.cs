using Domain.Entities.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BoardingApp.IBoardingRepos
{
    public interface IBoardingCrudRepository
    {
        Task CreateHorseBoardingAsync(HorseBoarding horseBoarding);


        Task UpdateBoardingAsync(HorseBoarding boarding);
    }
}
