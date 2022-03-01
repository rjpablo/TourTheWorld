using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bad.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourTheWorld.Data;
using TourTheWorld.Models;
using TourTheWorld.Services;

namespace TourTheWorld.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IToursService _toursService;

        public ToursController(ApplicationDbContext context,
            IToursService toursService)
        {
            _context = context;
            _toursService = toursService;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourModel>>> GetTours()
        {
            return await _context.Tours.ToListAsync();
        }

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourModel>> GetTourModel(long id)
        {
            var tourModel = await _context.Tours.FindAsync(id);

            if (tourModel == null)
            {
                return NotFound();
            }

            return tourModel;
        }

        [HttpGet]
        [Route("[action]/{tourId}/{mediaId}")]
        public async Task SetPrimaryMedia(long tourId, long mediaId)
        {
            await _toursService.SetPrimaryMedia(tourId, mediaId);
        }

        // PUT: api/Tours/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourModel(long id, TourModel tourModel)
        {
            if (id != tourModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(tourModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tours
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("[action]")]
        public async Task<TourModel> AddTour(TourModel tourModel)
        {
            return await _toursService.Create(tourModel);
        }

        [HttpPost]
        [Route("[action]/{tourId}")]
        public async Task<List<MultimediaModel>> AddTourPhotos(long tourId, List<IFormFile> files)
        {
            return await _toursService.AddTourMedia(files, tourId);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TourModel>> DeleteTourModel(long id)
        {
            var tourModel = await _context.Tours.FindAsync(id);
            if (tourModel == null)
            {
                return NotFound();
            }

            _context.Tours.Remove(tourModel);
            await _context.SaveChangesAsync();

            return tourModel;
        }

        private bool TourModelExists(long id)
        {
            return _context.Tours.Any(e => e.Id == id);
        }
    }
}
