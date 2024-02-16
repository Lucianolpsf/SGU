using SGU.Models;
using SGU.ORM;
using System.Runtime.CompilerServices;

namespace SGU.ConfSistema
{
    public class ConfManutencao
    {
        private SguContext _context;
        public ConfManutencao(SguContext context)
        {
            _context = context;
        }        
        public List<ManutencaoVM> ListarManutencoes()
        {
            List<ManutencaoVM> ListManutencoes = new List<ManutencaoVM>();

            var list = _context.Manutencaos.ToList();

            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    ManutencaoVM mnt = new ManutencaoVM();
                    {
                        mnt.Id = (int)item.Id;
                        mnt.Tecnica = item.Tecnica;
                        mnt.Valor = item.Valor;
                        mnt.Prazo = item.Prazo;
                        mnt.FkServico = item.FkServico;


                    }

                    ListManutencoes.Add(mnt);
                }

                return ListManutencoes;
            }
            else
            {
                return null;
            }
        }
        public string InserirManutencao(string tecnica, decimal valor, int prazo, int idSer)
        
        {
            OperacaoResultado resultado = new OperacaoResultado();

            try
            {
                Manutencao mnt = new Manutencao();
                mnt.Tecnica = tecnica;
                mnt.Valor = valor;
                mnt.Prazo = prazo;
                mnt.FkServico= idSer;

                _context.Manutencaos.Add(mnt);
                _context.SaveChanges();

                resultado.Success = true;
                resultado.Message = "Manutenção inserida com sucesso";
                return resultado.Message;
            }
            catch (Exception ex)
            {
                resultado.Success = false;
                resultado.Message = $"Erro ao inserir a Manutenção: {ex.Message}";
                return resultado.Message;
            }
        }
        public bool AlterarManutencao(int Id, string tecnica, decimal valor, int prazo, int idSer)
        {
            try
            {                
                Manutencao mnt = _context.Manutencaos.Find(Id);

                if (mnt != null)
                {
                    mnt.Id = Id;
                    mnt.Tecnica = tecnica;
                    mnt.Valor = valor; 
                    mnt.Prazo = prazo;  
                    mnt.FkServico= idSer;
                    
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
        public bool ExcluirManutencao(int id)
        {
            try
            {
                Manutencao mnt = new Manutencao();

                mnt = _context.Manutencaos.Where(a => a.Id == id).FirstOrDefault();
                if (mnt != null)
                {
                    _context.Manutencaos.Remove(mnt);

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
