using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvalCore.Data;
using EvalCore.Models;

namespace EvalCore.Controllers
{
    public class PeriodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeriodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Periodo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Evaluacion.ToListAsync());
        }

        // GET: Periodo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluacion
                .FirstOrDefaultAsync(m => m.KeyEval == id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // GET: Periodo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Periodo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KeyEval,Periodoinicial,Periodofinal,Fecha,Usuario,Estado")] Evaluacion evaluacion)
        {
            //validar cantidad registros x año
            int año = evaluacion.Fecha.Value.Year;
            int totalregistrosxaño = _context.Evaluacion.Count(e => e.Periodofinal.Value.Year == año);
            
            if(totalregistrosxaño < 2)
            {
                //fragmento codigo original
                if (ModelState.IsValid)
                {
                    _context.Add(evaluacion);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                //retornar mensaje en el mismo formulario de guardar
                return NotFound();
            }

     
            return View(evaluacion);
        }

        // GET: Periodo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluacion.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }
            ViewBag.Est = evaluacion.Estado.ToString();
            return View(evaluacion);
        }

        // POST: Periodo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KeyEval,Periodoinicial,Periodofinal,Fecha,Usuario,Estado")] Evaluacion evaluacion)
        {
            if (id != evaluacion.KeyEval)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluacionExists(evaluacion.KeyEval))
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
            return View(evaluacion);
        }

        // GET: Periodo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluacion
                .FirstOrDefaultAsync(m => m.KeyEval == id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // POST: Periodo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluacion = await _context.Evaluacion.FindAsync(id);
            _context.Evaluacion.Remove(evaluacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluacionExists(int id)
        {
            return _context.Evaluacion.Any(e => e.KeyEval == id);
        }
    }
}
