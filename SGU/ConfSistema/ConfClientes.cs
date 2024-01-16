using System.Collections.Generic;
using SGC.Models;
using SGU.ORM;

namespace SGC.ConfProjeto
{
    public class ConfClientes
    {
        private SguContext _context;

        public ConfClientes(SguContext context)
        {
            _context = context;
        }

        public List<ClienteVM> ListarContato()
        {
            List<ClienteVM> ListaContato = new List<ClienteVM>();

            var list = _context.Clientes.ToList();

            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    ClienteVM contatoVM = new ClienteVM();
                    {
                        contatoVM.Id = item.Id;
                        contatoVM.Nome = item.Nome;
                        contatoVM.Email = item.Email;
                        contatoVM.Telefone = item.Telefone;
                        contatoVM.Mensagem = item.Mensagem;
                    }

                    ListaContato.Add(contatoVM);
                }

                return ListaContato;
            }
            else
            {
                return null;
            }
        }

        public bool AlterarCliente(int Id, string Nome, string Email, string Telefone)
        {

            try
            {
                // Encontrar o usuário no banco de dados pelo Id
                Cliente usr = _context.Clientes.Find(Id);

                if (usr != null)
                {
                    usr.Id = Id;
                    usr.Nome = Nome;
                    usr.Email = Email;
                    usr.Telefone = Telefone;

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

        public bool DeletarCliente(int id)
        {
            try
            {
                Cliente usr = new Cliente();

                usr = _context.Clientes.Where(a => a.Id == id).FirstOrDefault();
                if (usr != null)
                {
                    _context.Clientes.Remove(usr);

                }
                _context.SaveChanges();
                return true;
            }

            catch (Exception)
            {

                return false;
            }
        }
    }
}

