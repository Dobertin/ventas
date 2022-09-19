using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventas.Infraestructure.Data.Context;
using Ventas.Infraestructure.Data.Entities;

namespace Ventas.Client.Controllers
{
    public class ClientesController : Controller
    {
        private readonly VentasContext _context;
        public ClientesController(VentasContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var VentasContext = _context.Clientes;
            return View(await VentasContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente", "nombres", "apellidos", "TipoDoc", "NroDoc", "telefono", "celular")] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(cliente);
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
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente", "nombres", "apellidos", "TipoDoc", "NroDoc", "telefono", "celular")] Cliente cliente)
        {
            try
            {
                if (id != cliente.IdCliente)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(cliente);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VentaExists(cliente.IdCliente))
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
                return View(cliente);
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
            var cliente = await _context.Clientes 
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                _context.Clientes.Remove(cliente);
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
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
