using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatApp.Models;

namespace ChatApp.Controllers
{
    public class BerichtenController : Controller
    {
        private readonly BerichtContext _context;

        public BerichtenController(BerichtContext context)
        {
            _context = context;
        }

        // GET: Berichten
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bericht.ToListAsync());
        }

        // GET: Berichten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bericht = await _context.Bericht
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bericht == null)
            {
                return NotFound();
            }

            return View(bericht);
        }

        // GET: Berichten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Berichten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Content,Datum")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bericht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bericht);
        }

        // GET: Berichten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bericht = await _context.Bericht.SingleOrDefaultAsync(m => m.ID == id);
            if (bericht == null)
            {
                return NotFound();
            }
            return View(bericht);
        }

        // POST: Berichten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Content,Datum")] Bericht bericht)
        {
            if (id != bericht.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bericht);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BerichtExists(bericht.ID))
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
            return View(bericht);
        }

        // GET: Berichten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bericht = await _context.Bericht
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bericht == null)
            {
                return NotFound();
            }

            return View(bericht);
        }

        // POST: Berichten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bericht = await _context.Bericht.SingleOrDefaultAsync(m => m.ID == id);
            _context.Bericht.Remove(bericht);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BerichtExists(int id)
        {
            return _context.Bericht.Any(e => e.ID == id);
        }
    }
}
