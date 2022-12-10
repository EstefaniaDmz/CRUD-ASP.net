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
    public class TuristumsController : Controller
    {
        private readonly AgenciaViajesContext _context;

        public TuristumsController(AgenciaViajesContext context)
        {
            _context = context;
        }

        // GET: Turistums
        public async Task<IActionResult> Index()
        {
            var agenciaViajesContext = _context.Turista.Include(t => t.IdHotelNavigation).Include(t => t.IdSucursalNavigation).Include(t => t.IdUsuarioCreaNavigation).Include(t => t.IdUsuarioModificaNavigation).Include(t => t.IdVueloNavigation);
            return View(await agenciaViajesContext.ToListAsync());
        }

        // GET: Turistums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Turista == null)
            {
                return NotFound();
            }

            var turistum = await _context.Turista
                .Include(t => t.IdHotelNavigation)
                .Include(t => t.IdSucursalNavigation)
                .Include(t => t.IdUsuarioCreaNavigation)
                .Include(t => t.IdUsuarioModificaNavigation)
                .Include(t => t.IdVueloNavigation)
                .FirstOrDefaultAsync(m => m.IdTurista == id);
            if (turistum == null)
            {
                return NotFound();
            }

            return View(turistum);
        }

        // GET: Turistums/Create
        public IActionResult Create()
        {
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel");
            ViewData["IdSucursal"] = new SelectList(_context.Sucursals, "IdSucursal", "IdSucursal");
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            ViewData["IdVuelo"] = new SelectList(_context.Vuelos, "IdVuelo", "IdVuelo");
            return View();
        }

        // POST: Turistums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTurista,Nombre,ApellidoPaterno,ApellidoMaterno,Telefono,Calle,Colonia,Cp,IdHotel,RegimenHotel,IdSucursal,IdVuelo,ClaseTurista,Estatus,IdUsuarioCrea,FechaCrea,IdUsuarioModifica,FechaModifica")] Turistum turistum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turistum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", turistum.IdHotel);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursals, "IdSucursal", "IdSucursal", turistum.IdSucursal);
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", turistum.IdUsuarioCrea);
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", turistum.IdUsuarioModifica);
            ViewData["IdVuelo"] = new SelectList(_context.Vuelos, "IdVuelo", "IdVuelo", turistum.IdVuelo);
            return View(turistum);
        }

        // GET: Turistums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Turista == null)
            {
                return NotFound();
            }

            var turistum = await _context.Turista.FindAsync(id);
            if (turistum == null)
            {
                return NotFound();
            }
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", turistum.IdHotel);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursals, "IdSucursal", "IdSucursal", turistum.IdSucursal);
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", turistum.IdUsuarioCrea);
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", turistum.IdUsuarioModifica);
            ViewData["IdVuelo"] = new SelectList(_context.Vuelos, "IdVuelo", "IdVuelo", turistum.IdVuelo);
            return View(turistum);
        }

        // POST: Turistums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTurista,Nombre,ApellidoPaterno,ApellidoMaterno,Telefono,Calle,Colonia,Cp,IdHotel,RegimenHotel,IdSucursal,IdVuelo,ClaseTurista,Estatus,IdUsuarioCrea,FechaCrea,IdUsuarioModifica,FechaModifica")] Turistum turistum)
        {
            if (id != turistum.IdTurista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turistum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuristumExists(turistum.IdTurista))
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
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", turistum.IdHotel);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursals, "IdSucursal", "IdSucursal", turistum.IdSucursal);
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", turistum.IdUsuarioCrea);
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", turistum.IdUsuarioModifica);
            ViewData["IdVuelo"] = new SelectList(_context.Vuelos, "IdVuelo", "IdVuelo", turistum.IdVuelo);
            return View(turistum);
        }

        // GET: Turistums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Turista == null)
            {
                return NotFound();
            }

            var turistum = await _context.Turista
                .Include(t => t.IdHotelNavigation)
                .Include(t => t.IdSucursalNavigation)
                .Include(t => t.IdUsuarioCreaNavigation)
                .Include(t => t.IdUsuarioModificaNavigation)
                .Include(t => t.IdVueloNavigation)
                .FirstOrDefaultAsync(m => m.IdTurista == id);
            if (turistum == null)
            {
                return NotFound();
            }

            return View(turistum);
        }

        // POST: Turistums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Turista == null)
            {
                return Problem("Entity set 'AgenciaViajesContext.Turista'  is null.");
            }
            var turistum = await _context.Turista.FindAsync(id);
            if (turistum != null)
            {
                _context.Turista.Remove(turistum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuristumExists(int id)
        {
          return _context.Turista.Any(e => e.IdTurista == id);
        }
    }
}
