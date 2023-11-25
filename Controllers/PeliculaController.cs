using CineApp.Data;
using CineApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineApp.Controllers
{
    public class PeliculaController : Controller
    {
        private readonly CineDBContext _context;

        public PeliculaController(CineDBContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Peliculas == null)
            {
                return NotFound();
            }

            var pelicula = _context.Peliculas.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nombre,DuracionEnMin,FechaEstreno,Descripcion")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                _context.Peliculas.Add(pelicula);
                _context.SaveChanges();
                return RedirectToAction(nameof(Details));
            }
            return View(pelicula);
        }

        // GET: Usuarios/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Peliculas == null)
            {
                return NotFound();
            }

            var pelicula = _context.Peliculas.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Nombre,DuracionEnMin,FechaEstreno,Descripcion")] Pelicula pelicula)
        {
            if (id != pelicula.IdPelicula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var peliculaEnDb = _context.Peliculas.Find(id);
                    if (peliculaEnDb != null)
                    {
                        peliculaEnDb.Descripcion = pelicula.Descripcion;


                        _context.Peliculas.Update(peliculaEnDb);
                        _context.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.IdPelicula))
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
            return View(pelicula);
        }

        // GET: Usuario/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Peliculas == null)
            {
                return NotFound();
            }

            var pelicula = _context.Peliculas.Find(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Peliculas == null)
            {
                return Problem("Entity set 'CineDBContext.Usuario'  is null.");
            }
            var pelicula = _context.Peliculas.Find(id);
            if (pelicula != null)
            {
                _context.Peliculas.Remove(pelicula);
                _context.SaveChanges();
            }


            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaExists(int id)
        {
            return (_context.Peliculas?.Any(e => e.IdPelicula == id)).GetValueOrDefault();
        }
        private bool PeliculaExistByName(string nombre)
        {
            return (_context.Peliculas?.Any(e => e.NombrePelicula == nombre)).GetValueOrDefault();
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

