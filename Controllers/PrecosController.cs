using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioBenner.Data;
using DesafioBenner.Models;

namespace DesafioBenner.Controllers
{
    public class PrecosController : Controller
    {
        private readonly DesafioBennerContext _context;

        public PrecosController(DesafioBennerContext context)
        {
            _context = context;
        }

        // GET: Precos
        public async Task<IActionResult> Index()
        {
              return _context.Precos != null ? 
                          View(await _context.Precos.ToListAsync()) :
                          Problem("Entity set 'DesafioBennerContext.Precos'  is null.");
        }

        // GET: Precos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Precos == null)
            {
                return NotFound();
            }

            var precos = await _context.Precos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (precos == null)
            {
                return NotFound();
            }

            return View(precos);
        }

        // GET: Precos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Precos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor_inicial,Valor_adicional,Data_inicial,Data_final")] Precos precos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(precos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(precos);
        }

        // GET: Precos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Precos == null)
            {
                return NotFound();
            }

            var precos = await _context.Precos.FindAsync(id);
            if (precos == null)
            {
                return NotFound();
            }
            return View(precos);
        }

        // POST: Precos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor_inicial,Valor_adicional,Data_inicial,Data_final")] Precos precos)
        {
            if (id != precos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(precos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrecosExists(precos.Id))
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
            return View(precos);
        }

        // GET: Precos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Precos == null)
            {
                return NotFound();
            }

            var precos = await _context.Precos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (precos == null)
            {
                return NotFound();
            }

            return View(precos);
        }

        // POST: Precos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Precos == null)
            {
                return Problem("Entity set 'DesafioBennerContext.Precos'  is null.");
            }
            var precos = await _context.Precos.FindAsync(id);
            if (precos != null)
            {
                _context.Precos.Remove(precos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrecosExists(int id)
        {
          return (_context.Precos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
