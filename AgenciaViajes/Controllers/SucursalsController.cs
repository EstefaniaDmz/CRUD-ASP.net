using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaViajes.Models;

namespace AgenciaViajes.Controllers
{
    public class SucursalsController : Controller
    {
        private readonly AgenciaViajesContext _context;

        public SucursalsController(AgenciaViajesContext context)
        {
            _context = context;
        }

        // GET: Sucursals
        public async Task<IActionResult> Index()
        {
            var agenciaViajesContext = _context.Sucursals.Include(s => s.IdUsuarioCreaNavigation).Include(s => s.IdUsuarioModificaNavigation);
            return View(await agenciaViajesContext.ToListAsync());
        }

        // GET: Sucursals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sucursals == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursals
                .Include(s => s.IdUsuarioCreaNavigation)
                .Include(s => s.IdUsuarioModificaNavigation)
                .FirstOrDefaultAsync(m => m.IdSucursal == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // GET: Sucursals/Create
        public IActionResult Create()
        {
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Sucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSucursal,Nombre,Telefono,Calle,Colonia,Cp,NumeroPlazas,Estatus,IdUsuarioCrea,FechaCrea,IdUsuarioModifica,FechaModifica")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucursal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", sucursal.IdUsuarioCrea);
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", sucursal.IdUsuarioModifica);
            return View(sucursal);
        }

        // GET: Sucursals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sucursals == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursals.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", sucursal.IdUsuarioCrea);
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", sucursal.IdUsuarioModifica);
            return View(sucursal);
        }

        // POST: Sucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSucursal,Nombre,Telefono,Calle,Colonia,Cp,NumeroPlazas,Estatus,IdUsuarioCrea,FechaCrea,IdUsuarioModifica,FechaModifica")] Sucursal sucursal)
        {
            if (id != sucursal.IdSucursal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalExists(sucursal.IdSucursal))
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
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", sucursal.IdUsuarioCrea);
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", sucursal.IdUsuarioModifica);
            return View(sucursal);
        }

        // GET: Sucursals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sucursals == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursals
                .Include(s => s.IdUsuarioCreaNavigation)
                .Include(s => s.IdUsuarioModificaNavigation)
                .FirstOrDefaultAsync(m => m.IdSucursal == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // POST: Sucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sucursals == null)
            {
                return Problem("Entity set 'AgenciaViajesContext.Sucursals'  is null.");
            }
            var sucursal = await _context.Sucursals.FindAsync(id);
            if (sucursal != null)
            {
                _context.Sucursals.Remove(sucursal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalExists(int id)
        {
          return _context.Sucursals.Any(e => e.IdSucursal == id);
        }
    }
}
