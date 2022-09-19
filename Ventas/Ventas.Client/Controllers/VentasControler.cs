using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ventas.Infraestructure.Data.Context;
using Ventas.Infraestructure.Data.Entities;

namespace Ventas.Client.Controllers
{
    public class VentasControler : Controller
    {
        private readonly VentasContext _context;
        public VentasControler(VentasContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var VentasContext = _context.Ventas.Include(p => p.IdAsesorNavigation).Include(p => p.IdClienteNavigation).Include(p => p.IdProductoNavigation);
            return View(await VentasContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas
                .Include(p => p.IdAsesorNavigation)
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (ventas== null)
            {
                return NotFound();
            }
            return View(ventas);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["IdAsesor"] = new SelectList(_context.Asesores, "IdAsesor", "Nombres");
            ViewData["IdCliente"] = new SelectList(_context.Asesores, "IdCliente", "Nombres");
            ViewData["IdProducto"] = new SelectList(_context.Asesores, "IdProducto", "NombreCom");
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta", "IdCliente", "IdAsesor", "IdProducto", "Periodo", "PuntosObtenidos", "FechaVenta", "MontoDesembolsado")] Venta venta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(venta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdAsesor"] = new SelectList(_context.Asesores, "IdAsesor", "Nombres",venta.IdAsesorNavigation);
                ViewData["IdCliente"] = new SelectList(_context.Asesores, "IdCliente", "Nombres", venta.IdClienteNavigation);
                ViewData["IdProducto"] = new SelectList(_context.Asesores, "IdProducto", "NombreCom", venta.IdProductoNavigation);
                return View(venta);
            }
            catch
            {
                return View();
            }
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["IdAsesor"] = new SelectList(_context.Asesores, "IdAsesor", "Nombres", venta.IdAsesorNavigation);
            ViewData["IdCliente"] = new SelectList(_context.Asesores, "IdCliente", "Nombres", venta.IdClienteNavigation);
            ViewData["IdProducto"] = new SelectList(_context.Asesores, "IdProducto", "NombreCom", venta.IdProductoNavigation);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta", "IdCliente", "IdAsesor", "IdProducto", "Periodo", "PuntosObtenidos", "FechaVenta", "MontoDesembolsado")] Venta venta)
        {
            try
            {
                if (id!= venta.IdVenta)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(venta);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VentaExists(venta.IdVenta))
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
                ViewData["IdAsesor"] = new SelectList(_context.Asesores, "IdAsesor", "Nombres", venta.IdAsesorNavigation);
                ViewData["IdCliente"] = new SelectList(_context.Asesores, "IdCliente", "Nombres", venta.IdClienteNavigation);
                ViewData["IdProducto"] = new SelectList(_context.Asesores, "IdProducto", "NombreCom", venta.IdProductoNavigation);
                return View(venta);
            }
            catch
            {
                return View();
            }
        }


        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var venta = await _context.Ventas
                .Include(p => p.IdAsesorNavigation)
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
               var venta = await _context.Ventas.FindAsync(id);
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private bool VentaExists(int idVenta)
        {
            return _context.Ventas.Any(e=> e.IdVenta == idVenta);
        }
    }
}
