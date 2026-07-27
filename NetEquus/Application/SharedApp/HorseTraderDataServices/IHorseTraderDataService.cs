using Shared.Dtos.BoardingDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SharedApp.HorseTraderDataServices
{
    public interface IHorseTraderDataService
    {
        Task<List<BoardingDto>> GetHorsesAtHorseTraderAsync();

    }
}
