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
                       //   View(await _context.ControleEstacionamento.Where(c => c.Placa.Contains(teste)).ToListAsync()) :
                          Problem("Entity set 'DesafioBennerContext.ControleEstacionamento'  is null.");
        }

        // Método que executa a busca por meio de uma nova View programada para retornar uma List com a expressão filtrada
        public async Task<IActionResult> IndexFilter(string busca)
        {
            return busca != null ?
                View(await _context.ControleEstacionamento.Where(c => c.Placa.Contains(busca)).ToListAsync()) :
                RedirectToAction(nameof(Index));
        }



        // GET: ControleEstacionamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControleEstacionamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,Tempo_entrada")] ControleEstacionamento controleEstacionamento)
        {
            if (ModelState.IsValid)
            {

                // Atribuição dos valores provenientes da tabela de preços
                var vigenciapreco = _context.Precos
                 .FirstOrDefault(p => controleEstacionamento.Tempo_entrada >= p.Data_inicial && controleEstacionamento.Tempo_entrada <= p.Data_final);

                if (vigenciapreco != null)
                {
                    controleEstacionamento.Valor_hora = vigenciapreco.Valor_inicial;
                    controleEstacionamento.Valor_adicional = vigenciapreco.Valor_adicional;
                }

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,Tempo_entrada,Tempo_saida,HorasTotais,Minutos,Valor_hora,Valor_adicional,Valor_final")] ControleEstacionamento controleEstacionamento)
        {
            if (id != controleEstacionamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Funções para setar os valores de horas, minutos, e calcular o valor final
                    DefineTempo(controleEstacionamento);
                    CalculaValorFinal(controleEstacionamento);

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

        public ControleEstacionamento DefineTempo(ControleEstacionamento c)
        {
            var tsaida = Convert.ToDateTime(c.Tempo_saida);

            c.HorasTotais = tsaida < c.Tempo_entrada ? 0 : Math.Floor(tsaida.Subtract(c.Tempo_entrada).TotalHours);
            c.Minutos = tsaida < c.Tempo_entrada ? 0 : tsaida.Subtract(c.Tempo_entrada).Minutes;

            return c;
        }

        public ControleEstacionamento CalculaValorFinal(ControleEstacionamento c)
        {
            if (c.HorasTotais == 0 && c.Minutos <= 30)
            {
                c.Valor_final = c.Valor_hora / 2;
            }
            else
            {
                if (c.Minutos <= 10)
                {
                    c.Valor_final = (c.Valor_hora + (c.HorasTotais == 1 ? 0 : c.Valor_adicional * (c.HorasTotais - 2)));
                }
                else
                {
                    c.Valor_final = (c.Valor_hora + (c.Valor_adicional * (c.HorasTotais - 1)));
                }
            }

            return c;
        } 
    }
}
