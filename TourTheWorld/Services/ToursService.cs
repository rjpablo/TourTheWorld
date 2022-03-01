using Bad.Core.Enums;
using Bad.Core.Models;
using Bad.Core.Services;
using Microsoft.AspNetCore.Http;
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
    public class ToursService : BaseService, IToursService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IFilesService _filesService;
        private readonly ITourMediaRepository _tourMediaRepository;
        private readonly IMultimediaRepository _multimediaRepository;

        public ToursService(ApplicationDbContext context,
            ITourRepository tourRepository,
            IFilesService filesService,
            ITourMediaRepository tourMediaRepository,
            IMultimediaRepository multimediaRepository)
            : base(context)
        {
            _tourRepository = tourRepository;
            _filesService = filesService;
            _tourMediaRepository = tourMediaRepository;
            _multimediaRepository = multimediaRepository;
        }

        public async Task<IEnumerable<TourModel>> GetToursAsync()
        {
            return await _tourRepository.Get(includeProperties: nameof(TourModel.PrimaryMedia)).ToListAsync();
        }

        public async Task<IEnumerable<MultimediaModel>> GetPhotosAsync(long tourId)
        {
            if (_tourRepository.Exists(tourId))
            {
                var tour = await _tourRepository.Get(filter: t => t.Id == tourId)
                    .Include(t => t.MediaList)
                    .ThenInclude(m => m.Media)
                    .SingleAsync();
                return tour.MediaList.Select(m => m.Media);
            }
            else
            {
                throw new KeyNotFoundException($"Tour with ID {tourId} does not exist.");
            }
        }

        public async Task<TourModel> Create(TourModel tour)
        {
            _tourRepository.Insert(tour);
            await _tourRepository.SaveChangesAsync();
            return tour;
        }

        public async Task SetPrimaryMedia(long tourId, long mediaId)
        {
            var tour = await _tourRepository.GetByIDAsync(tourId);
            if (tour == null) throw new KeyNotFoundException($"Tour with ID {tourId} does not exist.");

            var media = await _multimediaRepository.GetByIDAsync(mediaId);
            if (media == null) throw new KeyNotFoundException($"Media with ID {tourId} does not exist.");

            tour.PrimaryMediaId = mediaId;
            _tourRepository.Update(tour);
            await SaveAsync();
        }

        public async Task<List<MultimediaModel>> AddTourMedia(List<IFormFile> files, long tourId)
        {
            using (var transaction = BeginTransaction())
            {
                try
                {
                    List<MultimediaModel> result = new List<MultimediaModel>();
                    for (int x = 0; x < files.Count(); x++)
                    {
                        var file = files[x];
                        string url = await _filesService.Upload(file);
                        var media = new MultimediaModel(url, MultimediaTypeEnum.Photo, "", "");
                        _multimediaRepository.Insert(media);
                        await SaveAsync();
                        var tourMedia = new TourMediaModel(tourId, media.Id);
                        _tourMediaRepository.Insert(tourMedia);
                        await SaveAsync();
                        result.Add(media);
                    }

                    transaction.Commit();
                    return result;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<TourModel> GetTourByIdAsync(long id)
        {
            return await _tourRepository.GetByIDAsync(id);
        }
    }
}
