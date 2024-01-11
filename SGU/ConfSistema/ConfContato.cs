using Microsoft.EntityFrameworkCore;
using SGC.Models;
using SGU.ORM;

namespace SGC.ConfProjeto
{
    public class ConfContato
    {
        private SguContext _context;

        public ConfContato(SguContext context)
        {
            _context = context;

        }



        public List<ContatoVM> ListarContato()
        {
            List<ContatoVM> ListaContato = new List<ContatoVM>();

            var list = _context.Contatos.ToList();

            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    ContatoVM contatoVM = new ContatoVM();
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
    }
}
