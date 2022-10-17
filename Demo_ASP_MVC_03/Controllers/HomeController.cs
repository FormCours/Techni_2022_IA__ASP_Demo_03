using Demo_ASP_MVC_03.Data;
using Demo_ASP_MVC_03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo_ASP_MVC_03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Récuperation du nombre d'inscription
            int nbInscription = FakeDB.GetInscription().Count();

            // Envoi des données à la vue via le ViewData
            ViewData["NbInscrit"] = nbInscription;

            // Génération (et envoi) de la vue
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