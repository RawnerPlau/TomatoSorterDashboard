using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TomatoSorterDashboard.Data;
using TomatoSorterDashboard.Models;

namespace TomatoSorterDashboard.Controllers
{
    public class TomatoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TomatoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tomatoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tomato.ToListAsync());
        }

        // GET: Tomatoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tomato = await _context.Tomato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tomato == null)
            {
                return NotFound();
            }

            return View(tomato);
        }

        // GET: Tomatoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tomatoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsDefect,Ripeness,DateScanned")] Tomato tomato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tomato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tomato);
        }

        // GET: Tomatoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tomato = await _context.Tomato.FindAsync(id);
            if (tomato == null)
            {
                return NotFound();
            }
            return View(tomato);
        }

        // POST: Tomatoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsDefect,Ripeness,DateScanned")] Tomato tomato)
        {
            if (id != tomato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tomato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TomatoExists(tomato.Id))
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
            return View(tomato);
        }

        // GET: Tomatoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tomato = await _context.Tomato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tomato == null)
            {
                return NotFound();
            }

            return View(tomato);
        }

        // POST: Tomatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tomato = await _context.Tomato.FindAsync(id);
            if (tomato != null)
            {
                _context.Tomato.Remove(tomato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TomatoExists(int id)
        {
            return _context.Tomato.Any(e => e.Id == id);
        }
    }
}
