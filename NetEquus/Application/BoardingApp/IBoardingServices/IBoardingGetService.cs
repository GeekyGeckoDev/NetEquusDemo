using Domain.Entities.Models.Horses.Relations;
using Shared.Dtos.BoardingDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BoardingApp.IBoardingServices
{
    public interface IBoardingGetService
    {
        Task<List<BoardingDto>> GetBoardingByEstateIdAsync(Guid estateId);

        Task<HorseBoarding> GetBoardingByHorseIdAsync(Guid horseId);
    }
}
