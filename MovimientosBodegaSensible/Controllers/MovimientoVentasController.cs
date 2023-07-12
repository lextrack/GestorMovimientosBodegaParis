using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovimientosBodegaSensible.Models;

namespace MovimientosBodegaSensible.Controllers
{
    public class MovimientoVentasController : Controller
    {
        private readonly MovimientosParisContext _context;

        public MovimientoVentasController(MovimientosParisContext context)
        {
            _context = context;
        }

        // GET: MovimientoVentas, pagination and serching items
        public async Task<IActionResult> Index(string buscarVenta, int pg = 1)
        {
            var venta = from ventas in _context.MovimientoVentas select ventas;

            if (!String.IsNullOrEmpty(buscarVenta))
            {
                venta = venta.Where(s => s.Producto!.Contains(buscarVenta) || s.Boleta.ToString().Contains(buscarVenta) || s.Sku.ToString().Contains(buscarVenta));
            }

            const int pageSize = 15;
            if (pg < 1)
                pg = 1;

            int recsCount = await venta.CountAsync();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            venta = venta.OrderByDescending(s => s.Fecha)
                         .ThenBy(s => s.Producto);

            var data = await venta.Skip(recSkip).Take(pager.PageSize).ToListAsync();

            this.ViewBag.Pager = pager;

            return View(data);
        }


        // GET: MovimientoVentas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.MovimientoVentas == null)
            {
                return NotFound();
            }

            var movimientoVenta = await _context.MovimientoVentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimientoVenta == null)
            {
                return NotFound();
            }

            return View(movimientoVenta);
        }

        // GET: MovimientoVentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovimientoVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Producto,Boleta,Sku,Cantidad,Responsable")] MovimientoVenta movimientoVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientoVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movimientoVenta);
        }

        // GET: MovimientoVentas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.MovimientoVentas == null)
            {
                return NotFound();
            }

            var movimientoVenta = await _context.MovimientoVentas.FindAsync(id);
            if (movimientoVenta == null)
            {
                return NotFound();
            }
            return View(movimientoVenta);
        }

        // POST: MovimientoVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Fecha,Producto,Boleta,Sku,Cantidad,Responsable")] MovimientoVenta movimientoVenta)
        {
            if (id != movimientoVenta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientoVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoVentaExists(movimientoVenta.Id))
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
            return View(movimientoVenta);
        }

        // GET: MovimientoVentas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.MovimientoVentas == null)
            {
                return NotFound();
            }

            var movimientoVenta = await _context.MovimientoVentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimientoVenta == null)
            {
                return NotFound();
            }

            return View(movimientoVenta);
        }

        // POST: MovimientoVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.MovimientoVentas == null)
            {
                return Problem("Entity set 'MovimientosParisContext.MovimientoVentas'  is null.");
            }
            var movimientoVenta = await _context.MovimientoVentas.FindAsync(id);
            if (movimientoVenta != null)
            {
                _context.MovimientoVentas.Remove(movimientoVenta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoVentaExists(long id)
        {
            return (_context.MovimientoVentas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
