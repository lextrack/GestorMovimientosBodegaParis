using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovimientosBodegaSensible.Models;

namespace MovimientosBodegaSensible.Controllers
{
    public class RecepcionsController : Controller
    {
        private readonly MovimientosParisContext _context;

        public RecepcionsController(MovimientosParisContext context)
        {
            _context = context;
        }

        // GET: Recepcions
        public async Task<IActionResult> Index()
        {
            return _context.Recepcions != null ?
                        View(await _context.Recepcions.ToListAsync()) :
                        Problem("Entity set 'MovimientosParisContext.Recepcions'  is null.");
        }

        // GET: Recepcions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Recepcions == null)
            {
                return NotFound();
            }

            var recepcion = await _context.Recepcions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recepcion == null)
            {
                return NotFound();
            }

            return View(recepcion);
        }

        // GET: Recepcions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recepcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Dpto,Cantidad,Responsable")] Recepcion recepcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recepcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recepcion);
        }

        // GET: Recepcions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Recepcions == null)
            {
                return NotFound();
            }

            var recepcion = await _context.Recepcions.FindAsync(id);
            if (recepcion == null)
            {
                return NotFound();
            }
            return View(recepcion);
        }

        // POST: Recepcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Fecha,Dpto,Cantidad,Responsable")] Recepcion recepcion)
        {
            if (id != recepcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recepcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecepcionExists(recepcion.Id))
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
            return View(recepcion);
        }

        // GET: Recepcions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Recepcions == null)
            {
                return NotFound();
            }

            var recepcion = await _context.Recepcions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recepcion == null)
            {
                return NotFound();
            }

            return View(recepcion);
        }

        // POST: Recepcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Recepcions == null)
            {
                return Problem("Entity set 'MovimientosParisContext.Recepcions'  is null.");
            }
            var recepcion = await _context.Recepcions.FindAsync(id);
            if (recepcion != null)
            {
                _context.Recepcions.Remove(recepcion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecepcionExists(long id)
        {
            return (_context.Recepcions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
