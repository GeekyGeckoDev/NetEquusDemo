using Domain.Entities.Models.Horses.Relations;
using Shared.Dtos.BoardingDtos;
using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BoardingApp.IBoardingRepos
{
    public interface IBoardingGetRepository
    {
        Task<List<BoardingDto>> GetBoardingsByEstateId(Guid estateId);

        Task<HorseBoarding> GetBoardingByHorseId(Guid horseId);

        Task<List<BoardingDto>> SearchBoardingsAsync(Guid estateId, string? search, int? sex);

        Task<List<HorseInfoDto>> GetEligibleMaresAsync(Guid estateId);

    }
}
