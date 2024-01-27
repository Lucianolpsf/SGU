using SGU.ORM;
using System;
using System.Collections.Generic;

namespace SGC.Models;

public class ManutencaoVM
{
    public int Id { get; set; }

    public string? Tecnica { get; set; }

    public decimal? ValorManutencao { get; set; }

    public int? FkAgendamentoId { get; set; }

    public virtual Agendamento? FkAgendamento { get; set; }
}
