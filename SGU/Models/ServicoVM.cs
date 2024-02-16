using SGU.ORM;

namespace SGU.Models
{
    public class ServicoVM
    {
        public int Id { get; set; }

        public string? Tecnica { get; set; }

        public double? Valor { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; } = new List<Agendamento>();

    }
}
