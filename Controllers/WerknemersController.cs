using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Data;
using GeoProfs.Models;

namespace GeoProfs.Controllers
{
    public class WerknemersController : Controller
    {
        private readonly BedrijfContext _context;

        public WerknemersController(BedrijfContext context)
        {
            _context = context;
        }

        // Displays all werknemers in the database.
        public async Task<IActionResult> Index()
        {
            return View(await _context.Werknemers.ToListAsync());
        }

        // GET: Werknemers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var werknemer = await _context.Werknemers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (werknemer == null)
            {
                return NotFound();
            }

            return View(werknemer);
        }

        // GET: Werknemers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Werknemers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,functie_ID,voornaam,achternaam,geboortedatum,BSN,telefoonnummer,email,wachtwoord,contract_uren,uurloon")] Werknemer werknemer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(werknemer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(werknemer);
        }

        // GET: Werknemers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var werknemer = await _context.Werknemers.FindAsync(id);
            if (werknemer == null)
            {
                return NotFound();
            }
            return View(werknemer);
        }

        // POST: Werknemers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,functie_ID,voornaam,achternaam,geboortedatum,BSN,telefoonnummer,email,wachtwoord,contract_uren,uurloon")] Werknemer werknemer)
        {
            if (id != werknemer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(werknemer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WerknemerExists(werknemer.ID))
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
            return View(werknemer);
        }

        // GET: Werknemers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var werknemer = await _context.Werknemers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (werknemer == null)
            {
                return NotFound();
            }

            return View(werknemer);
        }

        // POST: Werknemers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var werknemer = await _context.Werknemers.FindAsync(id);
            _context.Werknemers.Remove(werknemer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WerknemerExists(int id)
        {
            return _context.Werknemers.Any(e => e.ID == id);
        }
    }
}
