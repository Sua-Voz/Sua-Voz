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
    public class FaixaEtariaController : Controller
    {
        private readonly Context _context;

        public FaixaEtariaController(Context context)
        {
            _context = context;
        }

        // GET: FaixaEtaria
        public async Task<IActionResult> Index()
        {
            return View(await _context.FaixasEtarias.ToListAsync());
        }

        // GET: FaixaEtaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faixaEtaria = await _context.FaixasEtarias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faixaEtaria == null)
            {
                return NotFound();
            }

            return View(faixaEtaria);
        }

        // GET: FaixaEtaria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FaixaEtaria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] FaixaEtaria faixaEtaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faixaEtaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faixaEtaria);
        }

        // GET: FaixaEtaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faixaEtaria = await _context.FaixasEtarias.FindAsync(id);
            if (faixaEtaria == null)
            {
                return NotFound();
            }
            return View(faixaEtaria);
        }

        // POST: FaixaEtaria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] FaixaEtaria faixaEtaria)
        {
            if (id != faixaEtaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faixaEtaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaixaEtariaExists(faixaEtaria.Id))
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
            return View(faixaEtaria);
        }

        // GET: FaixaEtaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faixaEtaria = await _context.FaixasEtarias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faixaEtaria == null)
            {
                return NotFound();
            }

            return View(faixaEtaria);
        }

        // POST: FaixaEtaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faixaEtaria = await _context.FaixasEtarias.FindAsync(id);
            _context.FaixasEtarias.Remove(faixaEtaria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaixaEtariaExists(int id)
        {
            return _context.FaixasEtarias.Any(e => e.Id == id);
        }
    }
}
