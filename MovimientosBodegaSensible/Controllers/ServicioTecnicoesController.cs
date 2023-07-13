using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovimientosBodegaSensible.Models;

namespace MovimientosBodegaSensible.Controllers
{
    public class ServicioTecnicoesController : Controller
    {
        private readonly MovimientosParisContext _context;

        public ServicioTecnicoesController(MovimientosParisContext context)
        {
            _context = context;
        }

        // GET: ServicioTecnicoes
        public async Task<IActionResult> Index(string buscarServicioTecnico, int pg = 1)
        {
            var serviciotecnico = from serviciotecnicos in _context.ServicioTecnicoes select serviciotecnicos;
            ViewBag.ErrorMessage = null;

            if (!String.IsNullOrEmpty(buscarServicioTecnico))
            {
                if (long.TryParse(buscarServicioTecnico, out long nguia))
                {
                    serviciotecnico = serviciotecnico.Where(s => s.Nguia == nguia);
                }
                else
                {
                    ViewBag.ErrorMessage = "Solo puedes ingresar números";
                }
            }

            const int pageSize = 15;
            if (pg < 1)
                pg = 1;

            int recsCount = await serviciotecnico.CountAsync();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            serviciotecnico = serviciotecnico.OrderByDescending(s => s.Fecha);

            var data = await serviciotecnico.Skip(recSkip).Take(pager.PageSize).ToListAsync();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        // GET: ServicioTecnicoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ServicioTecnicoes == null)
            {
                return NotFound();
            }

            var servicioTecnico = await _context.ServicioTecnicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioTecnico == null)
            {
                return NotFound();
            }

            return View(servicioTecnico);
        }

        // GET: ServicioTecnicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicioTecnicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Producto,CasoSiebel,Nguia,Responsable")] ServicioTecnico servicioTecnico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioTecnico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicioTecnico);
        }

        // GET: ServicioTecnicoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ServicioTecnicoes == null)
            {
                return NotFound();
            }

            var servicioTecnico = await _context.ServicioTecnicoes.FindAsync(id);
            if (servicioTecnico == null)
            {
                return NotFound();
            }
            return View(servicioTecnico);
        }

        // POST: ServicioTecnicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Fecha,Producto,CasoSiebel,Nguia,Responsable")] ServicioTecnico servicioTecnico)
        {
            if (id != servicioTecnico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioTecnico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioTecnicoExists(servicioTecnico.Id))
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
            return View(servicioTecnico);
        }

        // GET: ServicioTecnicoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ServicioTecnicoes == null)
            {
                return NotFound();
            }

            var servicioTecnico = await _context.ServicioTecnicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioTecnico == null)
            {
                return NotFound();
            }

            return View(servicioTecnico);
        }

        // POST: ServicioTecnicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ServicioTecnicoes == null)
            {
                return Problem("Entity set 'MovimientosParisContext.ServicioTecnicos'  is null.");
            }
            var servicioTecnico = await _context.ServicioTecnicoes.FindAsync(id);
            if (servicioTecnico != null)
            {
                _context.ServicioTecnicoes.Remove(servicioTecnico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioTecnicoExists(long id)
        {
            return (_context.ServicioTecnicoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
