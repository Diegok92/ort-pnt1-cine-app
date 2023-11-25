using CineApp.Data;
using CineApp.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace CineApp.Controllers
{
    public class LoginController : Controller
    {

        private readonly CineDBContext _context;

        public LoginController(CineDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind("Email,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
               Usuario? usuarioBuscado= BuscarUsuarioMail(usuario.Email,_context.Usuarios.ToList());
                if(usuarioBuscado != null && usuarioBuscado.mismaContraseña(usuario.Contraseña))
                {
                   return RedirectToAction("ElegirPelicula");
                } else
                {
                    return NotFound();
                }

            }
                return View();
        }

        [HttpGet]
        public IActionResult CrearReserva()
        {
           // ViewData["Funciones"] = new SelectList(_context.Funciones);

            ViewBag.Funciones = new SelectList(_context.Funciones);

            return View();
        }

        [HttpGet]
        public IActionResult ElegirPelicula()
        {

            ViewBag.Peliculas = new SelectList(_context.Peliculas);

            return View();
        }
        [HttpPost]
        public IActionResult ElegirPelicula([Bind("NombrePelicula")] Pelicula pelicula)
        {

            ViewBag.Peliculas = new SelectList(_context.Peliculas);
            if(pelicula.NombrePelicula.Equals("Spiderman"))
            {
                return RedirectToAction("ReservarSpiderman");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ReservarSpiderman()
        {

        

            return View();
        }



        private Usuario? BuscarUsuarioMail(string email,List<Usuario> lista)
        {
            Usuario usuarioEncontrado = null;
            Usuario usuarioActual = null;
            int i = 0;

            while (usuarioEncontrado == null && i<lista.Count)
            {usuarioActual = lista[i];
                if (usuarioActual.mismoEmail(email))
                {
                    usuarioEncontrado = usuarioActual;
                }
                i++;

            }
            return usuarioEncontrado;

        }

        // GET: Usuarios/Details/5


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
        public IActionResult Create([Bind("IdUsuario,Email,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(UsuarioExistsByEmail(usuario.Email))
                {
                  var usuarioEnDb =  _context.Usuarios.Find(usuario.IdUsuario);
                    if(usuarioEnDb.Contraseña == usuario.Contraseña)
                    {
                        return RedirectToAction(nameof(Pelicula));
                    }

                }
                else
                {
                    return NotFound();
                }
               
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Pelicula()
        {
            return View(_context.Peliculas.ToList());
        }
        [HttpPost]
        public IActionResult Pelicula([Bind("IdPelicula")] Pelicula pelicula)
        {
            return RedirectToAction(nameof(Reserva));
        }




        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
        private bool UsuarioExistsByEmail(string email)
        {
            return (_context.Usuarios?.Any(e => e.Email == email)).GetValueOrDefault();
        }

        

    }
}
