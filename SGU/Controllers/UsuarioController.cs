using Microsoft.AspNetCore.Mvc;

namespace SGU.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
