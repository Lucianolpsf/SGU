using Microsoft.AspNetCore.Http;
using SGU.Models;
using SGU.ORM;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SGU.ConfSistema
{
    public class ConfAgendamento
    {
        private SguContext _context;
        public ConfAgendamento(SguContext context)
        {
            _context = context;
        }        
        public List<ViewAgendamentoVM> ListarAgendamentos()
        {
            List<ViewAgendamentoVM> ListaAgendamento = new List<ViewAgendamentoVM>();

            var list = _context.ViewAgendamentos.ToList();

            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    ViewAgendamentoVM LstVM = new ViewAgendamentoVM();
                    {

                        LstVM.Id = item.Id;
                        LstVM.Nome = item.Nome;
                        LstVM.Email = item.Email;
                        LstVM.Telefone = item.Telefone;                       
                        LstVM.AgendarData = item.AgendarData;
                        LstVM.Horario = item.Horario;
                        LstVM.Tecnica = item.Tecnica;
                        LstVM.Valor = item.Valor;
                        LstVM.Confirmacao = item.Confirmacao;
                        LstVM.Satisfacao = item.Satisfacao;
                    }

                    ListaAgendamento.Add(LstVM);
                }

                return ListaAgendamento;
            }
            else
            {
                return null;
            }
        }
        public List<ServicoVM> ListarServicos()
        {
            List<ServicoVM> ListaServico = new List<ServicoVM>();

            var list = _context.Servicos.ToList();

            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    ServicoVM Serv = new ServicoVM();
                    {
                        Serv.Id = item.Id;
                        Serv.Tecnica = item.Tecnica;                       
                        Serv.Valor = item.Valor;
                    }

                    ListaServico.Add(Serv);
                }

                return ListaServico;
            }
            else
            {
                return null;
            }
        }
        public List<TipoServicoVM> ListarTipoServico()
        {
            List<TipoServicoVM> ListaTipoServico = new List<TipoServicoVM>();

            var list = _context.TipoServicos.ToList();

            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    TipoServicoVM TipoServ = new TipoServicoVM();
                    {
                        
                        TipoServ.Id= item.Id;
                        TipoServ.Tipo = item.Tipo;
                            
                            
                    }

                    ListaTipoServico.Add(TipoServ);
                }

                return ListaTipoServico;
            }
            else
            {
                return null;
            }
        }
        public List<Agendamento> ConsultarAgendamento(string datap)
        {
            List<Agendamento> ListaAgendamento = new List<Agendamento>();

            DateTime data = DateTime.ParseExact(datap, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string dataFormatada = data.ToString("yyyy-MM-dd"); // Formato desejado: "yyyy-MM-dd"

            try
            {
                ListaAgendamento = _context.Agendamentos.Where(a => a.AgendarData == DateTime.Parse(dataFormatada)).ToList();

                return ListaAgendamento;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar agendamentos: {ex.Message}");
                return ListaAgendamento;
            }
        }
        public bool InserirAgendamento(int id, string dataC, string data, int servico, TimeSpan atendimento)
        {
            try
            { 
                Agendamento agt = new Agendamento();
                DateTime dtHoraAgendamento;
                DateTime AgendarDat;
                agt.Horario = atendimento;
                agt.FkUsuarioId = id;
                agt.FkServicoId = servico;
                if (DateTime.TryParse(dataC, out dtHoraAgendamento))
                {                   
                    agt.DtHoraAgendamento = dtHoraAgendamento;
                }
                if (DateTime.TryParse(data, out AgendarDat))
                {                   
                    agt.AgendarData = AgendarDat;
                }
                _context.Agendamentos.Add(agt);
                    _context.SaveChanges();
                    return true;
                                
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
        public bool ExcluirAgendamento(int id)
        {
            try
            {
                Agendamento agt = new Agendamento();

                agt = _context.Agendamentos.Where(a => a.Id == id).FirstOrDefault();
                if (agt != null)
                {
                    _context.Agendamentos.Remove(agt);

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
