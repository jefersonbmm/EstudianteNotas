using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOTASDEESTUDIANTE.Models;

namespace NOTASDEESTUDIANTE.Controllers
{
    public class NotasEstudiantesController : Controller
    {
        private readonly NotasDBContext _context;

        public NotasEstudiantesController(NotasDBContext context)
        {
            _context = context;
        }

        // GET: NotasEstudiantes
        public async Task<IActionResult> Index()
        {
              return View(await _context.NotasEstudiantes.ToListAsync());
        }


        // GET: NotasEstudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NotasEstudiantes == null)
            {
                return NotFound();
            }

            var notasEstudiante = await _context.NotasEstudiantes
                .FirstOrDefaultAsync(m => m.IdnotasEstudiantes == id);
            if (notasEstudiante == null)
            {
                return NotFound();
            }

            return View(notasEstudiante);
        }

        // GET: NotasEstudiantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NotasEstudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdnotasEstudiantes,Carnet,Apellido,Nombre,NotaIp,NotaIip,NotaSist,NotaProy,NotaFinal")] NotasEstudiante notasEstudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notasEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notasEstudiante);
        }

        // GET: NotasEstudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NotasEstudiantes == null)
            {
                return NotFound();
            }

            var notasEstudiante = await _context.NotasEstudiantes.FindAsync(id);
            if (notasEstudiante == null)
            {
                return NotFound();
            }
            return View(notasEstudiante);
        }

        // POST: NotasEstudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdnotasEstudiantes,Carnet,Apellido,Nombre,NotaIp,NotaIip,NotaSist,NotaProy,NotaFinal")] NotasEstudiante notasEstudiante)
        {
            if (id != notasEstudiante.IdnotasEstudiantes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notasEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotasEstudianteExists(notasEstudiante.IdnotasEstudiantes))
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
            return View(notasEstudiante);
        }

        // GET: NotasEstudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NotasEstudiantes == null)
            {
                return NotFound();
            }

            var notasEstudiante = await _context.NotasEstudiantes
                .FirstOrDefaultAsync(m => m.IdnotasEstudiantes == id);
            if (notasEstudiante == null)
            {
                return NotFound();
            }

            return View(notasEstudiante);
        }

        // POST: NotasEstudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NotasEstudiantes == null)
            {
                return Problem("Entity set 'NotasDBContext.NotasEstudiantes'  is null.");
            }
            var notasEstudiante = await _context.NotasEstudiantes.FindAsync(id);
            if (notasEstudiante != null)
            {
                _context.NotasEstudiantes.Remove(notasEstudiante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotasEstudianteExists(int id)
        {
          return _context.NotasEstudiantes.Any(e => e.IdnotasEstudiantes == id);
        }
    }
}
