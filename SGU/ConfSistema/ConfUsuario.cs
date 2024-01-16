using SGC.Models;
using SGU.ORM;

namespace SGU.ConfSistema
{
    public class ConfUsuario
    {
        private SguContext _context;
        public ConfUsuario(SguContext context)
        {
            _context = context;
        }

        public Usuario ConsultarUsuario(string email, string senha)
        {
            try
            {
                var user = _context.Usuarios.FirstOrDefault(a => a.Email == email && a.Senha == senha);

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar usuário: {ex.Message}");
                return null;
            }
        }
    }
}
