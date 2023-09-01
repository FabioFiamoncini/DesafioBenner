using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioBenner.Models;
using DesafioBenner.Data;

namespace DesafioBenner.Controllers
{
    public class ControleEstacionamentoController : Controller
    {
        private readonly DesafioBennerContext _context;

        public ControleEstacionamentoController(DesafioBennerContext context)
        {
            _context = context;
        }

        // GET: ControleEstacionamento
        public async Task<IActionResult> Index()
        {
              return _context.ControleEstacionamento != null ? 
                          View(await _context.ControleEstacionamento.ToListAsync()) :
                          Problem("Entity set 'DesafioBennerContext.ControleEstacionamento'  is null.");
        }

        // GET: ControleEstacionamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ControleEstacionamento == null)
            {
                return NotFound();
            }

            var controleEstacionamento = await _context.ControleEstacionamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controleEstacionamento == null)
            {
                return NotFound();
            }

            return View(controleEstacionamento);
        }

        // GET: ControleEstacionamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControleEstacionamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,Tempo_entrada,Tempo_saida,Duracao,Valor_hora,Valor_adicional,Valor_final")] ControleEstacionamento controleEstacionamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controleEstacionamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controleEstacionamento);
        }

        // GET: ControleEstacionamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ControleEstacionamento == null)
            {
                return NotFound();
            }

            var controleEstacionamento = await _context.ControleEstacionamento.FindAsync(id);
            if (controleEstacionamento == null)
            {
                return NotFound();
            }
            return View(controleEstacionamento);
        }

        // POST: ControleEstacionamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,Tempo_entrada,Tempo_saida,Duracao,Valor_hora,Valor_adicional,Valor_final")] ControleEstacionamento controleEstacionamento)
        {
            if (id != controleEstacionamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controleEstacionamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControleEstacionamentoExists(controleEstacionamento.Id))
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
            return View(controleEstacionamento);
        }

        // GET: ControleEstacionamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ControleEstacionamento == null)
            {
                return NotFound();
            }

            var controleEstacionamento = await _context.ControleEstacionamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controleEstacionamento == null)
            {
                return NotFound();
            }

            return View(controleEstacionamento);
        }

        // POST: ControleEstacionamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ControleEstacionamento == null)
            {
                return Problem("Entity set 'DesafioBennerContext.ControleEstacionamento'  is null.");
            }
            var controleEstacionamento = await _context.ControleEstacionamento.FindAsync(id);
            if (controleEstacionamento != null)
            {
                _context.ControleEstacionamento.Remove(controleEstacionamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControleEstacionamentoExists(int id)
        {
          return (_context.ControleEstacionamento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
