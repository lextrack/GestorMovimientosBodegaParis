using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovimientosBodegaSensible.Models;

namespace MovimientosBodegaSensible.Controllers
{
    public class SacsController : Controller
    {
        private readonly MovimientosParisContext _context;

        public SacsController(MovimientosParisContext context)
        {
            _context = context;
        }

        // GET: Sacs
        public async Task<IActionResult> Index(string buscarTramiteSac, int pg = 1)
        {
            var sac = from sacs in _context.Sacs select sacs;

            if (!String.IsNullOrEmpty(buscarTramiteSac))
            {
                sac = sac.Where(s => s.Descripcion!.Contains(buscarTramiteSac));
            }

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recsCount = await sac.CountAsync();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            sac = sac.OrderByDescending(s => s.Fecha)
                         .ThenBy(s => s.Descripcion);

            var data = await sac.Skip(recSkip).Take(pager.PageSize).ToListAsync();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        // GET: Sacs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Sacs == null)
            {
                return NotFound();
            }

            var sac = await _context.Sacs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sac == null)
            {
                return NotFound();
            }

            return View(sac);
        }

        // GET: Sacs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,TipoMovimiento,Descripcion,Sku,Cantidad,NumeroOrden,Responsable")] Sac sac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sac);
        }

        // GET: Sacs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Sacs == null)
            {
                return NotFound();
            }

            var sac = await _context.Sacs.FindAsync(id);
            if (sac == null)
            {
                return NotFound();
            }
            return View(sac);
        }

        // POST: Sacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Fecha,TipoMovimiento,Descripcion,Sku,Cantidad,NumeroOrden,Responsable")] Sac sac)
        {
            if (id != sac.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SacExists(sac.Id))
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
            return View(sac);
        }

        // GET: Sacs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Sacs == null)
            {
                return NotFound();
            }

            var sac = await _context.Sacs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sac == null)
            {
                return NotFound();
            }

            return View(sac);
        }

        // POST: Sacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Sacs == null)
            {
                return Problem("Entity set 'MovimientosParisContext.Sacs'  is null.");
            }
            var sac = await _context.Sacs.FindAsync(id);
            if (sac != null)
            {
                _context.Sacs.Remove(sac);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SacExists(long id)
        {
            return (_context.Sacs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
