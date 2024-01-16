using System;
using System.Linq;
using SGC.Models;
using SGU.ORM;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc; // Certifique-se de adicionar a referência a este namespace

namespace SGC.ConfProjeto
{
    public class Usuario : Controller
    {
        private SguContext _context;

        public Usuario(SguContext context)
        {
            _context = context;
        }



        // No seu controlador, ao autenticar o usuário
        public IActionResult ConsultarUsuario(string Email, string Senha)
        {
            try
            {
                SGU.ConfSistema.ConfUsuario cu = new SGU.ConfSistema.ConfUsuario(_context);
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

        public IActionResult Logout()
        {
            // Limpar a sessão
            HttpContext.Session.Clear();

            // Redirecionar para a página de login
            return RedirectToAction("Index", "Home");
        }

    }
}
