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
    public class ManutencaoController : Controller
    {
        private SguContext _context;
        public ManutencaoController(SguContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ConfAgendamento cf = new ConfAgendamento(_context);

            var lstS = cf.ListarServicos();

            List<SelectListItem> Srv = lstS
            .Select(servico => new SelectListItem { Value = servico.Id.ToString(), Text = servico.Tecnica })
            .ToList();

            ViewBag.lstSevicosM = Srv;


            ConfManutencao cfm = new ConfManutencao(_context);
            var listaServicos = cfm.ListarManutencoes();
            return View(listaServicos);
        }

        public IActionResult InserirManutencao(string tecnica, decimal valor, int prazo, int idSer)
        {
            try
            {
                ConfManutencao conf = new ConfManutencao(_context);
                var mensagem = conf.InserirManutencao(tecnica, valor,prazo, idSer);

                return Json(new { success = true, message = mensagem });
            }
            catch (Exception)
            {
                // Trate exceções, se necessário
                return Json(new { success = false, message = "Erro ao processar a solicitação" });
            }
        }

        public IActionResult AlterarManutencao(int id, string tecnica, decimal valor, int prazo, int idSer)
        {
            ConfManutencao agdt = new ConfManutencao(_context);

            var rs = agdt.AlterarManutencao(id,tecnica, valor, prazo, idSer);
            if (rs)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        public IActionResult ExcluirManutencao(int id)
        {
            ConfManutencao conf = new ConfManutencao(_context);
            var rs = conf.ExcluirManutencao(id);
            return Json(new { success = rs });

        }
    }
}
