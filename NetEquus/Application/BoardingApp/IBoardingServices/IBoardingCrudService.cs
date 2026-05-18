using Domain.Entities.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BoardingApp.IBoardingServices
{
    public interface IBoardingCrudService
    {
        Task CreateHorseBoardingAsync(HorseBoarding horseBoarding);
    }
}
