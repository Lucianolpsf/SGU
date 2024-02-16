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
    public class UsuarioController : Controller
    {
        private SguContext _context;
        public UsuarioController(SguContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<SelectListItem> tipoUsuario = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "administrador" },
                new SelectListItem { Value = "2", Text = "cliente" },
           
            // Adicione mais itens conforme necessário
            };
            ViewBag.lstTipoUsuario = new SelectList(tipoUsuario, "Value", "Text");
            ConfUsuario cf = new ConfUsuario(_context);
            var listaContato = cf.ListarUsuarios();
            return View(listaContato);
        }
        public IActionResult Login()
        {
           return View();   
        }
        public IActionResult Cadastro()
        {
            return View();
        }

        // No seu controlador, ao autenticar o usuário
        public IActionResult ConsultarUsuario(string Email, string Senha)
        {
            try
            {
                ConfUsuario cu = new ConfUsuario(_context);
                var usuario = cu.ConsultarUsuario(Email, Senha);

                if (usuario != null)
                {
                    // Armazene informações do usuário na sessão
                    HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
                    HttpContext.Session.SetString("UsuarioNome", usuario.Nome);
                    HttpContext.Session.SetString("UsuarioEmail", usuario.Email);
                    HttpContext.Session.SetString("UsuarioTipo", usuario.TipoUsuario);

                    return Json(new { success = true });
                }
                else
                {
                    // Usuário não encontrado
                    return Json(new { success = false, message = "Email ou senha incorretos." });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar usuário: {ex.Message}");
                return Json(new { success = false, message = "Erro ao consultar usuário." });
            }
        }
        public IActionResult InserirUsuario(string Nome, string Senha, string Email, string Telefone, string TipoUsuario)
        {
            try
            {
                ConfUsuario conf = new ConfUsuario(_context);
                var resultado = conf.InserirUsuario(Nome, Email, Senha, Telefone, TipoUsuario);

                if (resultado.Success)
                {
                    return Json(new { success = true, message = "Cliente inserido com sucesso" });
                }
                else
                {
                    return Json(new { success = false, message = resultado.Message });
                }
            }
            catch (Exception)
            {
                // Trate exceções, se necessário
                return Json(new { success = false, message = "Erro ao processar a solicitação" });
            }
        }
        public IActionResult AlterarUsuario([FromBody] UsuarioVM usuario)
        {
            try
            {
                ConfUsuario conf = new ConfUsuario(_context);

                var rs = conf.AlterarUsuario(usuario.Id, usuario.Nome, usuario.Senha, usuario.Email, usuario.Telefone,usuario.TipoUsuario);

                return Json(new { success = rs });

            }
            catch (Exception ex)
            {
                // Trate exceções, se necessário
                return Json(new { success = false });
            }

        }
        public IActionResult ExcluirUsuario(int id)
        {
            ConfUsuario conf = new ConfUsuario(_context);
            var rs = conf.ExcluirUsuario(id);
            return Json(new { success = rs });

        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Logout()
        {
            // Limpar a sessão
            HttpContext.Session.Clear();

            // Redirecionar para a página de login
            return RedirectToAction("Index", "Home");
        }

    }
}
