using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FoalingApp.IFoalingServices
{
    public interface IFoalingCrudService
    {
        Task CreateFoalingAsync(Foaling foaling);
    }
}
