using CineApp.Models;
using CineApp.Models.Actividades;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


using CineApp.Models.Entities;
using CineApp.Persistencia;

namespace CineApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Usuario_Persistencia controladorUsuarios = new Usuario_Persistencia();
        


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {   
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}