using CineApp.Data;
using CineApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CineApp.Controllers
{
    public class ReservaController : Controller
    {
        private readonly CineDBContext _context;

        public ReservaController(CineDBContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public IActionResult Index()
        {
            return View();
        }

        // GET: Usuarios/Details/5
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var Reserva =  _context.Reservas.Find(id);
            if (Reserva == null)
            {
                return NotFound();
            }

            return View(Reserva);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmailCliente,IdFuncion,CantidadEntradas")] Reserva  reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Reservas.Add(reserva);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Usuarios/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = _context.Reservas.Find(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EmailCliente,IdFuncion,CantidadEntradas")] Reserva reserva)
        {
            if (id != reserva.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var reservaEnDb = _context.Reservas.Find(id);
                    if (reservaEnDb != null)
                    {
                        reservaEnDb.CantidadEntradas = reserva.CantidadEntradas;


                        _context.Reservas.Update(reservaEnDb);
                        _context.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.IdReserva))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details));
            }
            return View(reserva);
        }

        // GET: Usuario/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = _context.Reservas.Find(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Reservas == null)
            {
                return Problem("Entity set 'CineDBContext.Usuario'  is null.");
            }
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                _context.SaveChanges();
            }


            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return (_context.Reservas?.Any(e => e.IdReserva == id)).GetValueOrDefault();
        }
        private bool ReservaExistsByEmail(string email)
        {
            return (_context.Reservas?.Any(e => e.EmailCliente == email)).GetValueOrDefault();
        }

        //Usuario/Delete2/idUs
        public async Task<IActionResult> Delete2([Bind("Email")] Usuario usuario)
        {


            var usuario2 = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Email == usuario.Email);
            if (usuario2 != null)
            {
                return DeleteConfirmed(usuario2.IdUsuario);
            }
            else
            {
                return NotFound();
            }


        }

    }
}

