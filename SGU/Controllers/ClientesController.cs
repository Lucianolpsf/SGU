using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGC.ConfProjeto;
using SGC.Models;
using SGU.Models;
using SGU.ORM;
using System.Diagnostics;

namespace SGU.Controllers
{
    public class ClientesController : Controller
    {
        private readonly SguContext _guContext;
        public ClientesController(SguContext context)
        {
            _guContext = context;

        }

        public IActionResult Index()
        {
            ConfClientes cf = new ConfClientes(_guContext);
            var listaContato = cf.ListarContato();
            return View(listaContato);
        }
        public IActionResult AlterarCliente([FromBody] ClienteVM cliente)
        {
            try
            {
                ConfClientes conf = new ConfClientes(_guContext);
                var rs = conf.AlterarCliente(cliente.Id, cliente.Nome, cliente.Email, cliente.Telefone);

                return Json(new { success = rs });

            }
            catch (Exception ex)
            {
                // Trate exceções, se necessário
                return Json(new { success = false });
            }

        }

        public IActionResult DeletarCliente(int id)
        {
            ConfClientes conf = new ConfClientes(_guContext);
            var rs = conf.DeletarCliente(id);
            return Json(new { success = rs });

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


