using Bad.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TourTheWorld.Models;

namespace TourTheWorld.Services
{
    public interface IToursService : IService
    {
        Task<IEnumerable<TourModel>> GetToursAsync();
        Task<TourModel> GetTourByIdAsync(long id);
    }
}
