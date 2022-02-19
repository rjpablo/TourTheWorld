using Bad.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TourTheWorld.Data;
using TourTheWorld.Models;
using TourTheWorld.Repositories;

namespace TourTheWorld.Services
{
    public class TourService:BaseService, ITourService
    {
        private readonly ITourRepository _tourRepository;

        public TourService(ApplicationDbContext context,
            ITourRepository tourRepository)
            : base(context)
        {
            _tourRepository = tourRepository;
        }

        public async Task<IEnumerable<TourModel>> GetToursAsync()
        {
            return await _tourRepository.Get(includeProperties: nameof(TourModel.PrimaryMedia)).ToListAsync();
        }

        public async Task<TourModel> GetTourByIdAsync(long id){
            return await _tourRepository.GetByIDAsync(id);
        }
    }
}
