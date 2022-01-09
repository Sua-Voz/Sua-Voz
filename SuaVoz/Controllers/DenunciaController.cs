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
    public class DenunciaController : Controller
    {
        private readonly Context _context;

        public DenunciaController(Context context)
        {
            _context = context;
        }

        // GET: Denuncia
        public async Task<IActionResult> Index()
        {
            var context = _context.Denuncias.Include(d => d.FaixaEtaria).Include(d => d.Genero).Include(d => d.Regiao).Include(d => d.TipoViolencia);
            return View(await context.ToListAsync());
        }

        // GET: Denuncia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncias
                .Include(d => d.FaixaEtaria)
                .Include(d => d.Genero)
                .Include(d => d.Regiao)
                .Include(d => d.TipoViolencia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // GET: Denuncia/Create
        public IActionResult Create()
        {
            ViewData["FaixaEtariaId"] = new SelectList(_context.FaixasEtarias, "Id", "Nome");
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nome");
            ViewData["RegiaoId"] = new SelectList(_context.Regioes, "Id", "Nome");
            ViewData["TipoViolenciaId"] = new SelectList(_context.TiposViolencia, "Id", "Nome");
            return View();
        }

        // POST: Denuncia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,GeneroId,FaixaEtariaId,RegiaoId,TipoViolenciaId,DataOcorrencia,Relato")] Denuncia denuncia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denuncia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FaixaEtariaId"] = new SelectList(_context.FaixasEtarias, "Id", "Nome", denuncia.FaixaEtariaId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nome", denuncia.GeneroId);
            ViewData["RegiaoId"] = new SelectList(_context.Regioes, "Id", "Nome", denuncia.RegiaoId);
            ViewData["TipoViolenciaId"] = new SelectList(_context.TiposViolencia, "Id", "Nome", denuncia.TipoViolenciaId);
            return View(denuncia);
        }

        // GET: Denuncia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncias.FindAsync(id);
            if (denuncia == null)
            {
                return NotFound();
            }
            ViewData["FaixaEtariaId"] = new SelectList(_context.FaixasEtarias, "Id", "Nome", denuncia.FaixaEtariaId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nome", denuncia.GeneroId);
            ViewData["RegiaoId"] = new SelectList(_context.Regioes, "Id", "Nome", denuncia.RegiaoId);
            ViewData["TipoViolenciaId"] = new SelectList(_context.TiposViolencia, "Id", "Nome", denuncia.TipoViolenciaId);
            return View(denuncia);
        }

        // POST: Denuncia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,GeneroId,FaixaEtariaId,RegiaoId,TipoViolenciaId,DataOcorrencia,Relato")] Denuncia denuncia)
        {
            if (id != denuncia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denuncia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenunciaExists(denuncia.Id))
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
            ViewData["FaixaEtariaId"] = new SelectList(_context.FaixasEtarias, "Id", "Nome", denuncia.FaixaEtariaId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nome", denuncia.GeneroId);
            ViewData["RegiaoId"] = new SelectList(_context.Regioes, "Id", "Nome", denuncia.RegiaoId);
            ViewData["TipoViolenciaId"] = new SelectList(_context.TiposViolencia, "Id", "Nome", denuncia.TipoViolenciaId);
            return View(denuncia);
        }

        // GET: Denuncia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncias
                .Include(d => d.FaixaEtaria)
                .Include(d => d.Genero)
                .Include(d => d.Regiao)
                .Include(d => d.TipoViolencia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // POST: Denuncia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var denuncia = await _context.Denuncias.FindAsync(id);
            _context.Denuncias.Remove(denuncia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenunciaExists(int id)
        {
            return _context.Denuncias.Any(e => e.Id == id);
        }
    }
}
