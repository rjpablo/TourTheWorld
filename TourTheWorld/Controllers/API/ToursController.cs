using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourTheWorld.Data;
using TourTheWorld.Models;

namespace TourTheWorld.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToursController(ApplicationDbContext context)
        {
            _context = context;
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
        public async Task<ActionResult<TourModel>> PostTourModel(TourModel tourModel)
        {
            _context.Tours.Add(tourModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourModel", new { id = tourModel.Id }, tourModel);
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
