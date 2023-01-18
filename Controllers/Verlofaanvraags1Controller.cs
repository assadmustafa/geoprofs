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
    public class Verlofaanvraags1Controller : Controller
    {
        private readonly BedrijfContext _context;

        public Verlofaanvraags1Controller(BedrijfContext context)
        {
            _context = context;
        }

        // GET: Verlofaanvraags1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Verlofaanvraagen.ToListAsync());
        }

        // GET: Verlofaanvraags1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verlofaanvraag = await _context.Verlofaanvraagen
                .FirstOrDefaultAsync(m => m.ID == id);
            if (verlofaanvraag == null)
            {
                return NotFound();
            }

            return View(verlofaanvraag);
        }

        // GET: Verlofaanvraags1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Verlofaanvraags1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,werknemer_ID,begin_datum,eind_datum,beschrijving,verlof_reden,status")] Verlofaanvraag verlofaanvraag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verlofaanvraag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verlofaanvraag);
        }

        // GET: Verlofaanvraags1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verlofaanvraag = await _context.Verlofaanvraagen.FindAsync(id);
            if (verlofaanvraag == null)
            {
                return NotFound();
            }
            return View(verlofaanvraag);
        }

        // POST: Verlofaanvraags1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,werknemer_ID,begin_datum,eind_datum,beschrijving,verlof_reden,status")] Verlofaanvraag verlofaanvraag)
        {
            if (id != verlofaanvraag.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verlofaanvraag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerlofaanvraagExists(verlofaanvraag.ID))
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
            return View(verlofaanvraag);
        }

        // GET: Verlofaanvraags1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verlofaanvraag = await _context.Verlofaanvraagen
                .FirstOrDefaultAsync(m => m.ID == id);
            if (verlofaanvraag == null)
            {
                return NotFound();
            }

            return View(verlofaanvraag);
        }

        // POST: Verlofaanvraags1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var verlofaanvraag = await _context.Verlofaanvraagen.FindAsync(id);
            _context.Verlofaanvraagen.Remove(verlofaanvraag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VerlofaanvraagExists(int id)
        {
            return _context.Verlofaanvraagen.Any(e => e.ID == id);
        }
    }
}
