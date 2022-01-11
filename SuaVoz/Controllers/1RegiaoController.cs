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
    public class RegiaoController : Controller
    {
        private readonly Context _context;

        public RegiaoController(Context context)
        {
            _context = context;
        }

        // GET: Regiao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regioes.ToListAsync());
        }

        // GET: Regiao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        // GET: Regiao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regiao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Regiao regiao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regiao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regiao);
        }

        // GET: Regiao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null)
            {
                return NotFound();
            }
            return View(regiao);
        }

        // POST: Regiao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Regiao regiao)
        {
            if (id != regiao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regiao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegiaoExists(regiao.Id))
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
            return View(regiao);
        }

        // GET: Regiao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        // POST: Regiao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regiao = await _context.Regioes.FindAsync(id);
            _context.Regioes.Remove(regiao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegiaoExists(int id)
        {
            return _context.Regioes.Any(e => e.Id == id);
        }
    }
}
