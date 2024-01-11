using Microsoft.AspNetCore.Mvc;

namespace SGU.Controllers
{
    public class ServicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
