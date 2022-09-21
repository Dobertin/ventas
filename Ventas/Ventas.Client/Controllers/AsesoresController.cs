using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventas.Infraestructure.Data.Context;
using Ventas.Infraestructure.Data.Entities;

namespace Ventas.Client.Controllers
{
    public class AsesoresController : Controller
    {
        private readonly VentasContext _context;
        public AsesoresController(VentasContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var VentasContext = _context.Productos;
            return View(await VentasContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asesores = await _context.Asesores
                .FirstOrDefaultAsync(m => m.IdAsesor == id);
            if (asesores == null)
            {
                return NotFound();
            }
            return View(asesores);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsesor", "Usuario", "Nombres", "Apellido", "TipoDoc", "NroDoc", "CantVentas", "MetaPropuesta")] Asesore asesores)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(asesores);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(asesores);
            }
            catch
            {
                return View();
            }
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var asesores = await _context.Ventas.FindAsync(id);
            if (asesores == null)
            {
                return NotFound();
            }
            return View(asesores);
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsesor", "Usuario", "Nombres", "Apellido", "TipoDoc", "NroDoc", "CantVentas", "MetaPropuesta")] Asesore asesores)
        {
            try
            {
                if (id != asesores.IdAsesor)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(asesores);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VentaExists(asesores.IdAsesor))
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
                return View(asesores);
            }
            catch
            {
                return View();
            }
        }


        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var asesores = await _context.Asesores
                .FirstOrDefaultAsync(m => m.IdAsesor == id);
            if (asesores == null)
            {
                return NotFound();
            }
            return View(asesores);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var asesores = await _context.Asesores.FindAsync(id);
                _context.Asesores.Remove(asesores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private bool VentaExists(int id)
        {
            return _context.Asesores.Any(e => e.IdAsesor == id);
        }
    }
}
