using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuaVoz.Models;

namespace SuaVoz.Controllers
{
    [Authorize]
    public class TipoViolenciaController : Controller
    {
        private readonly Context _context;

        public TipoViolenciaController(Context context)
        {
            _context = context;
        }

        // GET: TipoViolencia
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposViolencia.ToListAsync());
        }

        // GET: TipoViolencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoViolencia = await _context.TiposViolencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoViolencia == null)
            {
                return NotFound();
            }

            return View(tipoViolencia);
        }

        // GET: TipoViolencia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoViolencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoViolencia tipoViolencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoViolencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoViolencia);
        }

        // GET: TipoViolencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoViolencia = await _context.TiposViolencia.FindAsync(id);
            if (tipoViolencia == null)
            {
                return NotFound();
            }
            return View(tipoViolencia);
        }

        // POST: TipoViolencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoViolencia tipoViolencia)
        {
            if (id != tipoViolencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoViolencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoViolenciaExists(tipoViolencia.Id))
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
            return View(tipoViolencia);
        }

        // GET: TipoViolencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoViolencia = await _context.TiposViolencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoViolencia == null)
            {
                return NotFound();
            }

            return View(tipoViolencia);
        }

        // POST: TipoViolencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoViolencia = await _context.TiposViolencia.FindAsync(id);
            _context.TiposViolencia.Remove(tipoViolencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoViolenciaExists(int id)
        {
            return _context.TiposViolencia.Any(e => e.Id == id);
        }
    }
}
