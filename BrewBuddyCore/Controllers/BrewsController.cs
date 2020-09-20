using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrewBuddyCore.Data;
using BrewBuddyCore.Models;

namespace BrewBuddyCore.Controllers
{
    public class BrewsController : Controller
    {
        private readonly BrewBuddyCoreContext _context;

        public BrewsController(BrewBuddyCoreContext context)
        {
            _context = context;
        }

        // GET: Brews
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brew.ToListAsync());
        }

        // GET: Brews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brew = await _context.Brew
                .FirstOrDefaultAsync(m => m.BrewID == id);
            if (brew == null)
            {
                return NotFound();
            }

            return View(brew);
        }

        // GET: Brews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrewID,CreateDate,Name,Description,Style,Yield,OriginalGravity,FinalGravity,ABV")] Brew brew)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brew);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brew);
        }

        // GET: Brews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brew = await _context.Brew.FindAsync(id);
            if (brew == null)
            {
                return NotFound();
            }
            return View(brew);
        }

        // POST: Brews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrewID,CreateDate,Name,Description,Style,Yield,OriginalGravity,FinalGravity,ABV")] Brew brew)
        {
            if (id != brew.BrewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brew);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrewExists(brew.BrewID))
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
            return View(brew);
        }

        // GET: Brews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brew = await _context.Brew
                .FirstOrDefaultAsync(m => m.BrewID == id);
            if (brew == null)
            {
                return NotFound();
            }

            return View(brew);
        }

        // POST: Brews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brew = await _context.Brew.FindAsync(id);
            _context.Brew.Remove(brew);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrewExists(int id)
        {
            return _context.Brew.Any(e => e.BrewID == id);
        }
    }
}
