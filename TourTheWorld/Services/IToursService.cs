using Bad.Core.Models;
using Bad.Core.Services;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourTheWorld.Models;

namespace TourTheWorld.Services
{
    public interface IToursService : IService
    {
        Task<List<MultimediaModel>> AddTourMedia(List<IFormFile> files, long tourId);
        Task<IEnumerable<TourModel>> GetToursAsync();
        Task<TourModel> GetTourByIdAsync(long id);
        Task SetPrimaryMedia(long tourId, long mediaId);
        Task<TourModel> Create(TourModel tour);
        Task<TourModel> Update(TourModel tour);
        Task<IEnumerable<MultimediaModel>> GetPhotosAsync(long tourId);
    }
}
