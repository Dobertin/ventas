using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ventas.Infraestructure.Data.Context;
using Ventas.Infraestructure.Data.Entities;

namespace Ventas.Client.Controllers
{
    public class ProductoController : Controller
    {
        private readonly VentasContext _context;
        public ProductoController(VentasContext context)
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

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto", "NombreCom", "Tipo", "Puntos")] Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(producto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(producto);
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
            var producto = await _context.Ventas.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto", "NombreCom", "Tipo", "Puntos")] Producto producto)
        {
            try
            {
                if (id != producto.IdProducto)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(producto);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VentaExists(producto.IdProducto))
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
                return View(producto);
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
            var venta = await _context.Productos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
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
                var producto = await _context.Productos.FindAsync(id);
                _context.Productos.Remove(producto);
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
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
