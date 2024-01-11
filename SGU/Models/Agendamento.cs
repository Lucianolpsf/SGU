using SGU.ORM;
using System;
using System.Collections.Generic;

namespace SGC.Models;

public class AgendamentoVM
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public DateTime? DtAgendamento { get; set; }

    public int? FkServicoId { get; set; }

    public int? FkUsuarioId { get; set; }

    public virtual Servico? FkServico { get; set; }

    public virtual Usuario? FkUsuario { get; set; }

    public virtual ICollection<Manutencao> Manutencaos { get; set; } = new List<Manutencao>();
}
