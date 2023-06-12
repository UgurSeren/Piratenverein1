using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Piratenverein1.Models;

namespace Piratenverein1.Controllers
{
    public class KinderPiratsController : Controller
    {
        private readonly Pirat2Context _context;

        public KinderPiratsController(Pirat2Context context)
        {
            _context = context;
        }

        // GET: KinderPirats
        public async Task<IActionResult> Index()
        {
              return _context.KinderPirats != null ? 
                          View(await _context.KinderPirats.ToListAsync()) :
                          Problem("Entity set 'Pirat2Context.KinderPirats'  is null.");
        }

        // GET: KinderPirats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KinderPirats == null)
            {
                return NotFound();
            }

            var kinderPirat = await _context.KinderPirats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kinderPirat == null)
            {
                return NotFound();
            }
            
                return View(kinderPirat);
            
            
        }

        // GET: KinderPirats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KinderPirats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vorname,Nachname,Alt")] KinderPirat kinderPirat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kinderPirat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kinderPirat);
        }
        public async Task<IActionResult> CreateNew([Bind("Id,Vorname,Nachname,Alt")] KinderPirat kinderPirat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kinderPirat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kinderPirat);
        }
        // GET: KinderPirats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KinderPirats == null)
            {
                return NotFound();
            }

            var kinderPirat = await _context.KinderPirats.FindAsync(id);
            if (kinderPirat == null)
            {
                return NotFound();
            }
            return View(kinderPirat);
        }

        // POST: KinderPirats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vorname,Nachname,Alt")] KinderPirat kinderPirat)
        {
            if (id != kinderPirat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kinderPirat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KinderPiratExists(kinderPirat.Id))
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
            return View(kinderPirat);
        }

        // GET: KinderPirats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KinderPirats == null)
            {
                return NotFound();
            }

            var kinderPirat = await _context.KinderPirats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kinderPirat == null)
            {
                return NotFound();
            }

            return View(kinderPirat);
        }

        // POST: KinderPirats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KinderPirats == null)
            {
                return Problem("Entity set 'Pirat2Context.KinderPirats'  is null.");
            }
            var kinderPirat = await _context.KinderPirats.FindAsync(id);
            if (kinderPirat != null)
            {
                _context.KinderPirats.Remove(kinderPirat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KinderPiratExists(int id)
        {
          return (_context.KinderPirats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
