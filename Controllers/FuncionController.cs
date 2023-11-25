using CineApp.Data;
using CineApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CineApp.Controllers
{
    public class FuncionController : Controller
    {
        private readonly CineDBContext _context;

        public FuncionController(CineDBContext context)
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
            if (id == null || _context.Funciones == null)
            {
                return NotFound();
            }

            var funcion = _context.Funciones.Find(id);
            if (funcion == null)
            {
                return NotFound();
            }

            return View(funcion);
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
        public IActionResult Create([Bind("IdPelicula,IdSala,ButacasVendidas,Dia,Horario")] Funcion funcion)
        {
            if (ModelState.IsValid)
            {
                _context.Funciones.Add(funcion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Details));
            }
            return View(funcion);
        }

        // GET: Usuarios/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Funciones == null)
            {
                return NotFound();
            }

            var funcion = _context.Funciones.Find(id);
            if (funcion == null)
            {
                return NotFound();
            }
            return View(funcion);
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
                    if (!FuncionExists(pelicula.IdPelicula))
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
            if (id == null || _context.Funciones == null)
            {
                return NotFound();
            }

            var funcion = _context.Funciones.Find(id);

            if (funcion == null)
            {
                return NotFound();
            }

            return View(funcion);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Funciones == null)
            {
                return Problem("Entity set 'CineDBContext.Usuario'  is null.");
            }
            var funcion = _context.Funciones.Find(id);
            if (funcion != null)
            {
                _context.Funciones.Remove(funcion);
                _context.SaveChanges();
            }


            return RedirectToAction(nameof(Index));
        }

        private bool FuncionExists(int id)
        {
            return (_context.Funciones?.Any(e => e.IdFuncion == id)).GetValueOrDefault();
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
