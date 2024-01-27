using Microsoft.AspNetCore.Mvc;
using SGC.ConfProjeto;
using SGU.Models;
using SGU.ORM;
using System.Diagnostics;

namespace SGU.Controllers
{
    public class HomeController : Controller
    {
        private readonly SguContext _guContext;
        public HomeController(SguContext context)
        {
            _guContext = context;

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
