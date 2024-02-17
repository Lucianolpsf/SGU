using SGU.Models;
using SGU.ORM;
using System.Runtime.CompilerServices;

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
        public List<UsuarioVM> ListarUsuarios()
        {
            List<UsuarioVM> ListaUsuarios = new List<UsuarioVM>();

            var list = _context.Usuarios.ToList();

            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    UsuarioVM UsuarioVM = new UsuarioVM();
                    {
                        UsuarioVM.Id = (int)item.Id;
                        UsuarioVM.Nome = item.Nome;
                        UsuarioVM.Senha = item.Senha; 
                        UsuarioVM.Email = item.Email;
                        UsuarioVM.Telefone = item.Telefone;
                        UsuarioVM.TipoUsuario = item.TipoUsuario;

                    }

                    ListaUsuarios.Add(UsuarioVM);
                }

                return ListaUsuarios;
            }
            else
            {
                return null;
            }
        }
        public OperacaoResultado InserirUsuario(string nome, string email, string senha, string telefone, bool tipoUsuario)
        {
            OperacaoResultado resultado = new OperacaoResultado();

            try
            {
                // Verificar se o e-mail já existe no banco
                if (EmailJaExiste(email))
                {
                    resultado.Success = false;
                    resultado.Message = "E-mail já cadastrado";
                    return resultado;
                }

                // Criar um novo objeto Usuario
                Usuario usr = new Usuario();
                usr.Nome = nome;
                usr.Email = email;
                usr.Senha = senha;
                usr.Telefone = telefone;
                usr.TipoUsuario = tipoUsuario;

                // Adicionar o usuário ao contexto e salvar as mudanças
                _context.Usuarios.Add(usr);
                _context.SaveChanges();

                // Se a inserção for bem-sucedida, retornar mensagem de sucesso
                resultado.Success = true;
                resultado.Message = "Usuário inserido com sucesso";
                return resultado;
            }
            catch (Exception ex)
            {
                // Se ocorrer uma exceção, retornar mensagem de erro
                resultado.Success = false;
                resultado.Message = $"Erro ao inserir usuário: {ex.Message}";
                return resultado;
            }
        }
        public bool AlterarUsuario(int Id, string Nome, string Senha,  string Email, string Telefone, bool tipoUsuario)
        {

            try
            {
                // Encontrar o usuário no banco de dados pelo Id
                Usuario usr = _context.Usuarios.Find(Id);

                if (usr != null)
                {
                    usr.Id = Id;
                    usr.Nome = Nome;
                    usr.Senha = Senha;
                    usr.Email = Email;
                    usr.Telefone = Telefone;
                    usr.TipoUsuario = tipoUsuario;
                    // Marcar o usuário como modificado e salvar as alterações
                    _context.SaveChanges();

                    return true;
                }

                return false; // Retornar false se o usuário não for encontrado
            }
            catch (Exception)
            {
                // Lidar com exceções, logar ou tratar conforme necessário
                return false;
            }
        }
        public bool ExcluirUsuario(int id)
        {
            try
            {
                Usuario usr = new Usuario();

                usr = _context.Usuarios.Where(a => a.Id == id).FirstOrDefault();
                if (usr != null)
                {
                    _context.Usuarios.Remove(usr);

                }
                _context.SaveChanges();
                return true;
            }

            catch (Exception)
            {

                return false;
            }
        }
        private bool EmailJaExiste(string email)
        {
            // Verificar se há algum usuário com o mesmo e-mail no banco
            return _context.Usuarios.Any(u => u.Email == email);
        }
    }
}
