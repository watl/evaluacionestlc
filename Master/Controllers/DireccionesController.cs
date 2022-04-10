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
    public class DireccionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DireccionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Direcciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Direcciones.ToListAsync());
        }

        // GET: Direcciones/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direcciones = await _context.Direcciones
                .FirstOrDefaultAsync(m => m.DirId == id);
            if (direcciones == null)
            {
                return NotFound();
            }

            return View(direcciones);
        }

        // GET: Direcciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirId,DirNombre,DirDescripcion,DirCentroCosto,DirUsuarioAud,DirFechaAud,DirActivo")] Direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direcciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(direcciones);
        }

        // GET: Direcciones/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direcciones = await _context.Direcciones.FindAsync(id);
            if (direcciones == null)
            {
                return NotFound();
            }
            return View(direcciones);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("DirId,DirNombre,DirDescripcion,DirCentroCosto,DirUsuarioAud,DirFechaAud,DirActivo")] Direcciones direcciones)
        {
            if (id != direcciones.DirId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direcciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionesExists(direcciones.DirId))
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
            return View(direcciones);
        }

        // GET: Direcciones/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direcciones = await _context.Direcciones
                .FirstOrDefaultAsync(m => m.DirId == id);
            if (direcciones == null)
            {
                return NotFound();
            }

            return View(direcciones);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var direcciones = await _context.Direcciones.FindAsync(id);
            _context.Direcciones.Remove(direcciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionesExists(decimal id)
        {
            return _context.Direcciones.Any(e => e.DirId == id);
        }
    }
}
