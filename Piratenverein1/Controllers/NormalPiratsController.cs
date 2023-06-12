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
    public class NormalPiratsController : Controller
    {
        private readonly Pirat2Context _context;

        public NormalPiratsController(Pirat2Context context)
        {
            _context = context;
        }

        // GET: NormalPirats
        public async Task<IActionResult> Index()
        {
              return _context.NormalPirats != null ? 
                          View(await _context.NormalPirats.ToListAsync()) :
                          Problem("Entity set 'Pirat2Context.NormalPirats'  is null.");
        }

        // GET: NormalPirats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NormalPirats == null)
            {
                return NotFound();
            }

            var normalPirat = await _context.NormalPirats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (normalPirat == null)
            {
                return NotFound();
            }

            return View(normalPirat);
        }

        // GET: NormalPirats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NormalPirats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vorname,Nachname,Alt")] NormalPirat normalPirat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(normalPirat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(normalPirat);
        }
        public async Task<IActionResult> CreateNew([Bind("Id,Vorname,Nachname,Alt")] NormalPirat normalPirat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(normalPirat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(normalPirat);
        }
        // GET: NormalPirats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NormalPirats == null)
            {
                return NotFound();
            }

            var normalPirat = await _context.NormalPirats.FindAsync(id);
            if (normalPirat == null)
            {
                return NotFound();
            }
            return View(normalPirat);
        }

        // POST: NormalPirats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vorname,Nachname,Alt")] NormalPirat normalPirat)
        {
            if (id != normalPirat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(normalPirat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NormalPiratExists(normalPirat.Id))
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
            return View(normalPirat);
        }

        // GET: NormalPirats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NormalPirats == null)
            {
                return NotFound();
            }

            var normalPirat = await _context.NormalPirats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (normalPirat == null)
            {
                return NotFound();
            }

            return View(normalPirat);
        }

        // POST: NormalPirats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NormalPirats == null)
            {
                return Problem("Entity set 'Pirat2Context.NormalPirats'  is null.");
            }
            var normalPirat = await _context.NormalPirats.FindAsync(id);
            if (normalPirat != null)
            {
                EhemaligePirat ehe = new EhemaligePirat();
                ehe.Vorname = normalPirat.Vorname;
                ehe.Nachname=normalPirat.Nachname;
                ehe.Alt=normalPirat.Alt;
                _context.NormalPirats.Remove(normalPirat);

                _context.EhemaligePirats.Add(ehe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NormalPiratExists(int id)
        {
          return (_context.NormalPirats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
