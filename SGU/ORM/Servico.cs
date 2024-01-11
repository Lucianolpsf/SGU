using System;
using System.Collections.Generic;

namespace SGU.ORM;

public partial class Servico
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public decimal? Valor { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}
