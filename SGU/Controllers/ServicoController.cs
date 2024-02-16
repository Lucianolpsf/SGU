using System;
using System.Linq;
using SGU.Models;
using SGU.ORM;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using SGU.ConfSistema;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering; // Certifique-se de adicionar a referência a este namespace

namespace SGC.ConfProjeto
{
    public class ServicoController : Controller
    {
        private SguContext _context;
        public ServicoController(SguContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        { 
            ConfServico cf = new ConfServico(_context);
            var listaServicos = cf.ListarServicos();
            return View(listaServicos);
        }
        public IActionResult InserirServico(string tecnica, float valor)
        {
            try
            {
                ConfServico conf = new ConfServico(_context);
                var mensagem = conf.InserirServico(tecnica, valor);

                return Json(new { success = true, message = mensagem });
            }
            catch (Exception)
            {
                // Trate exceções, se necessário
                return Json(new { success = false, message = "Erro ao processar a solicitação" });
            }
        }
        public IActionResult AlterarServico(int id, string tecnica, float valor)
        {
            ConfServico agdt = new ConfServico(_context);

            var rs = agdt.AlterarServico(id, tecnica, valor);
            if (rs)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
        public IActionResult ExcluirServico(int id)
        {
            ConfServico conf = new ConfServico(_context);
            var rs = conf.ExcluirServico(id);
            return Json(new { success = rs });

        }

    }
}
