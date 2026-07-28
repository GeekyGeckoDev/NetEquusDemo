using Application.FoalingApp.IFoalingRepos;
using Application.FoalingApp.IFoalingServices;
using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FoalingApp.FoalingServices
{
    public class FoalingGetService : IFoalingGetService
    {
        private readonly IFoalingGetRepository _repository;

        public FoalingGetService(IFoalingGetRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Foaling>> GetDueFoalingsAsync (Guid userId)
        {
            return await _repository.GetDueFoalingsAsync(userId);
        }
    }
}
