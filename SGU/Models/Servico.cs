

using SGU.ORM;

namespace SGC.Models;

public class ServicoVM
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public decimal? Valor { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}
