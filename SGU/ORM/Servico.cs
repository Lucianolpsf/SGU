using System;
using System.Collections.Generic;

namespace SGU.ORM;

public partial class Servico
{
    public int Id { get; set; }

    public string? Tecnica { get; set; }

    public double? Valor { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; } = new List<Agendamento>();
}
