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
    public class EhemaligePiratsController : Controller
    {
        private readonly Pirat2Context _context;

        public EhemaligePiratsController(Pirat2Context context)
        {
            _context = context;
        }

        // GET: EhemaligePirats
        public async Task<IActionResult> Index()
        {
              return _context.EhemaligePirats != null ? 
                          View(await _context.EhemaligePirats.ToListAsync()) :
                          Problem("Entity set 'Pirat2Context.EhemaligePirats'  is null.");
        }

        // GET: EhemaligePirats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EhemaligePirats == null)
            {
                return NotFound();
            }

            var ehemaligePirat = await _context.EhemaligePirats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ehemaligePirat == null)
            {
                return NotFound();
            }

            return View(ehemaligePirat);
        }

        // GET: EhemaligePirats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EhemaligePirats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vorname,Nachname,Alt")] EhemaligePirat ehemaligePirat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ehemaligePirat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ehemaligePirat);
        }

        // GET: EhemaligePirats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EhemaligePirats == null)
            {
                return NotFound();
            }

            var ehemaligePirat = await _context.EhemaligePirats.FindAsync(id);
            if (ehemaligePirat == null)
            {
                return NotFound();
            }
            return View(ehemaligePirat);
        }

        // POST: EhemaligePirats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vorname,Nachname,Alt")] EhemaligePirat ehemaligePirat)
        {
            if (id != ehemaligePirat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ehemaligePirat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EhemaligePiratExists(ehemaligePirat.Id))
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
            return View(ehemaligePirat);
        }

        // GET: EhemaligePirats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EhemaligePirats == null)
            {
                return NotFound();
            }

            var ehemaligePirat = await _context.EhemaligePirats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ehemaligePirat == null)
            {
                return NotFound();
            }

            return View(ehemaligePirat);
        }

        // POST: EhemaligePirats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EhemaligePirats == null)
            {
                return Problem("Entity set 'Pirat2Context.EhemaligePirats'  is null.");
            }
            var ehemaligePirat = await _context.EhemaligePirats.FindAsync(id);
            if (ehemaligePirat != null)
            {
                _context.EhemaligePirats.Remove(ehemaligePirat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EhemaligePiratExists(int id)
        {
          return (_context.EhemaligePirats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
