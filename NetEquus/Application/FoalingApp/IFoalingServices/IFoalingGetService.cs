using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FoalingApp.IFoalingServices
{
    public interface IFoalingGetService
    {
        Task<List<Foaling>> GetDueFoalingsAsync(Guid userId);
    }
}
