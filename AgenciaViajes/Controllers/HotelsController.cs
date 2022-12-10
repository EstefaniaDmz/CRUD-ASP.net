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
    public class HotelsController : Controller
    {
        private readonly AgenciaViajesContext _context;

        public HotelsController(AgenciaViajesContext context)
        {
            _context = context;
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            var agenciaViajesContext = _context.Hotels.Include(h => h.IdUsuarioCreaNavigation).Include(h => h.IdUsuarioModificaNavigation);
            return View(await agenciaViajesContext.ToListAsync());
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .Include(h => h.IdUsuarioCreaNavigation)
                .Include(h => h.IdUsuarioModificaNavigation)
                .FirstOrDefaultAsync(m => m.IdHotel == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHotel,Telefono,Nombre,Calle,Colonia,Cp,Ciudad,Estado,Pais,NumeroPlazas,Estatus,IdUsuarioCrea,FechaCrea,IdUsuarioModifica,FechaModifica")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", hotel.IdUsuarioCrea);
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", hotel.IdUsuarioModifica);
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", hotel.IdUsuarioCrea);
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", hotel.IdUsuarioModifica);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHotel,Telefono,Nombre,Calle,Colonia,Cp,Ciudad,Estado,Pais,NumeroPlazas,Estatus,IdUsuarioCrea,FechaCrea,IdUsuarioModifica,FechaModifica")] Hotel hotel)
        {
            if (id != hotel.IdHotel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.IdHotel))
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
            ViewData["IdUsuarioCrea"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", hotel.IdUsuarioCrea);
            ViewData["IdUsuarioModifica"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", hotel.IdUsuarioModifica);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .Include(h => h.IdUsuarioCreaNavigation)
                .Include(h => h.IdUsuarioModificaNavigation)
                .FirstOrDefaultAsync(m => m.IdHotel == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hotels == null)
            {
                return Problem("Entity set 'AgenciaViajesContext.Hotels'  is null.");
            }
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
          return _context.Hotels.Any(e => e.IdHotel == id);
        }
    }
}
