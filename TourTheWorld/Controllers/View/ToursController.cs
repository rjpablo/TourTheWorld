using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TourTheWorld.Data;
using TourTheWorld.Models;
using TourTheWorld.Repositories;
using TourTheWorld.Services;

namespace TourTheWorld.Controllers
{
    public class ToursController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToursService _tourService;
        private readonly ITourRepository _tourRepository;

        public ToursController(ApplicationDbContext context,
            IToursService tourService,
            ITourRepository tourRepository)
        {
            _context = context;
            _tourService = tourService;
            _tourRepository = tourRepository;
        }

        // GET: Tours
        public async Task<IActionResult> Index()
        {
            return View(await _tourService.GetToursAsync());
        }

        // GET: Tours/Details/5
        [Authorize]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourModel = await _tourService.GetTourByIdAsync(id.Value);
            if (tourModel == null)
            {
                return NotFound();
            }
             
            return View(tourModel);
        }

        // GET: Tours/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Price,Id,DateCreated")] TourModel tourModel)
        {
            if (ModelState.IsValid)
            {
                _tourRepository.Insert(tourModel);
                await _tourRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tourModel);
        }

        // GET: Tours/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourModel = await _context.Tours.FindAsync(id);
            if (tourModel == null)
            {
                return NotFound();
            }
            return View(tourModel);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Title,Description,Price,Id,DateCreated")] TourModel tourModel)
        {
            if (id != tourModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tourModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourModelExists(tourModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tourModel);
        }

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourModel = await _context.Tours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tourModel == null)
            {
                return NotFound();
            }

            return View(tourModel);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tourModel = await _context.Tours.FindAsync(id);
            _context.Tours.Remove(tourModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourModelExists(long id)
        {
            return _context.Tours.Any(e => e.Id == id);
        }
        protected override void Dispose(bool disposing)
        {
            _tourRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
