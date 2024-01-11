using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class AutenticacaoController : Controller
{
    // Ação para exibir a página de login
    public ActionResult Login()
    {
        return View();
    }

   
    [HttpPost]
    public IActionResult Login(string email, string senha)
    {
        // Lógica de autenticação aqui
        if (ValidarCredenciais(email, senha))
        {
            // Se as credenciais são válidas, configure a autenticação do usuário
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, email),
            
        };

            var identity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, 
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20) 
            };

            HttpContext.SignInAsync(principal, authProperties);

            
            return RedirectToAction("Index", "Home");
        }

        // Se as credenciais não são válidas, exiba uma mensagem de erro
        ViewBag.ErrorMessage = "Credenciais inválidas. Tente novamente.";

        return View();
    }

   
    private bool ValidarCredenciais(string email, string senha)
    {
        // Implemente sua lógica de validação de usuário/senha aqui
        // Por exemplo, consulte um banco de dados para verificar se as credenciais são válidas

       
        return email == "usuario" && senha == "senha";
    }





    // Ação para logout
    public ActionResult Logout()
    {
         HttpContext.SignOutAsync();

        return RedirectToAction("Index", "Home");

        
    }
}
