using SGU.Models;
using SGU.ORM;
using System.Runtime.CompilerServices;

namespace SGU.ConfSistema
{
    public class ConfServico
    {
        private SguContext _context;
        public ConfServico(SguContext context)
        {
            _context = context;
        }        
        public List<ServicoVM> ListarServicos()
        {
            List<ServicoVM> ListaServicos = new List<ServicoVM>();

            var list = _context.Servicos.ToList();

            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    ServicoVM srv = new ServicoVM();
                    {
                        srv.Id = (int)item.Id;
                        srv.Tecnica = item.Tecnica;
                        srv.Valor = item.Valor;


                    }

                    ListaServicos.Add(srv);
                }

                return ListaServicos;
            }
            else
            {
                return null;
            }
        }
        public string InserirServico(string tecnica, float valor)
        
        {
            OperacaoResultado resultado = new OperacaoResultado();

            try
            {
                Servico srv = new Servico();
                srv.Tecnica = tecnica;
                srv.Valor = valor;

                _context.Servicos.Add(srv);
                _context.SaveChanges();

                resultado.Success = true;
                resultado.Message = "Serviço inserido com sucesso";
                return resultado.Message;
            }
            catch (Exception ex)
            {
                resultado.Success = false;
                resultado.Message = $"Erro ao inserir Serviço: {ex.Message}";
                return resultado.Message;
            }
        }
        public bool AlterarServico(int Id, string tecnica, float valor)
        {
            try
            {                
                Servico srv = _context.Servicos.Find(Id);

                if (srv != null)
                {
                    srv.Id = Id;
                    srv.Tecnica = tecnica;
                    srv.Valor = valor;                    
                    
                    _context.SaveChanges();

                    return true;
                }

                return false; 
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ExcluirServico(int id)
        {
            try
            {
                Servico srv = new Servico();

                srv = _context.Servicos.Where(a => a.Id == id).FirstOrDefault();
                if (srv != null)
                {
                    _context.Servicos.Remove(srv);

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
