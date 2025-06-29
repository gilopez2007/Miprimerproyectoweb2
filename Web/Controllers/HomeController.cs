using Logica.Personas;
using Microsoft.AspNetCore.Mvc;
using Modelos.personas;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly persona_LN ln ;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ln = new persona_LN();
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Formulario1()
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
        #region CRUD
        [HttpPost]
        public IActionResult Agregarpersonayfrase(personas_VM personas)
        {
            string? errorMessage = null;
            bool resultado = true; /*ln.AgregarColaboradorYcontrato(personas, out errorMessage);*/

            if (resultado)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, error = errorMessage });
            }
        }
        #endregion

    }
}
