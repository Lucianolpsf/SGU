using Microsoft.AspNetCore.Mvc;
using SGC.ConfProjeto;
using SGU.Models;
using SGU.ORM;
using System.Diagnostics;

namespace SGU.Controllers
{
    public class ContatoController : Controller
    {
        private readonly SguContext _guContext;
        public ContatoController(SguContext context)
        {
            _guContext = context;

        }

        public IActionResult Index()
        {
            ConfContato cf = new ConfContato(_guContext);
            var listaContato = cf.ListarContato();
            return View(listaContato);
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
