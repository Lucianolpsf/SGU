using SGU.ORM;
using Microsoft.AspNetCore.Mvc;
using SGU.ConfSistema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SGC.ConfProjeto
{
    public class AgendamentoController : Controller
    {
        private SguContext _context;
        public AgendamentoController(SguContext context)
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

            ViewBag.lstSevicos = Srv;

            var listaHorario = new List<SelectListItem>
            {
                new SelectListItem { Value = "8", Text = "08:00:00" },
                new SelectListItem { Value = "10", Text = "10:00:00" },
                new SelectListItem { Value = "13", Text = "13:00:00" },
                new SelectListItem { Value = "15", Text = "15:00:00" },
                new SelectListItem { Value = "17", Text = "17:00:00" },
                new SelectListItem { Value = "19", Text = "19:00:00" }
            };

            
            ViewBag.lstHorarios = listaHorario;


            var listaAgendamento = cf.ListarAgendamentos();
            return View(listaAgendamento);
        }
        public IActionResult IndexCliente()
        {
            ConfAgendamento cf = new ConfAgendamento(_context);
             
            var lstS = cf.ListarServicos();

            List<SelectListItem> Srv = lstS
            .Select(servico => new SelectListItem { Value = servico.Id.ToString(), Text = servico.Tecnica })
            .ToList();

            ViewBag.lstSevicos = Srv;

            var listaHorario = new List<SelectListItem>
            {
                new SelectListItem { Value = "8", Text = "08:00:00" },
                new SelectListItem { Value = "10", Text = "10:00:00" },
                new SelectListItem { Value = "13", Text = "13:00:00" },
                new SelectListItem { Value = "15", Text = "15:00:00" },
                new SelectListItem { Value = "17", Text = "17:00:00" },
                new SelectListItem { Value = "19", Text = "19:00:00" }
            };


            ViewBag.lstHorarios = listaHorario;
            int id = Convert.ToInt32(HttpContext.Session.GetString("UsuarioId"));

            var listaAgendamento = cf.ListarAgendamentosCliente(id);
            return View(listaAgendamento);
        }
        public IActionResult Agendamento() 
        {

            ConfAgendamento cf = new ConfAgendamento(_context);

            var lstS = cf.ListarServicos();

            List<SelectListItem> Srv = lstS
            .Select(servico => new SelectListItem { Value = servico.Id.ToString(), Text = servico.Tecnica })
            .ToList();
            ViewBag.AgtSevicos = Srv;

            return View();
        }    
        public IActionResult ConsultarAgendamento(string data)
        {
            ConfAgendamento agdt = new ConfAgendamento(_context);
          
            var agendamento = agdt.ConsultarAgendamento(data); 

                if (agendamento != null)
                {
                    return Json(agendamento);
                }
                else
                {
                    return NotFound();
                }
           
        }        
        public IActionResult InserirAgendamentos(int id, string dataC, string data, int servico, List<string> atendimentos)
        {
            ConfAgendamento agdt = new ConfAgendamento(_context);

            foreach (var atendimento in atendimentos)
            {
                var rs = agdt.InserirAgendamento(id, dataC, data, servico, TimeSpan.Parse(atendimento));
                if (!rs)
                {
                    return Json(new { success = false });
                }
            }

            return Json(new { success = true });
        }
        public IActionResult AlterarAgendamentos(int id, string data, int servico, string horario)
        {
            ConfAgendamento agdt = new ConfAgendamento(_context);

          var rs =  agdt.AlterarAgendamento(id, data, servico, horario);
            if (rs)
            {
                return Json(new { success = true });
            }
            else 
            {
                return Json(new { success = false });
            }
        }
        public IActionResult ExcluirAgendamento(int id)
        {
            ConfAgendamento conf = new ConfAgendamento(_context);
            var rs = conf.ExcluirAgendamento(id);
            return Json(new { success = rs });

        }

    }
}
