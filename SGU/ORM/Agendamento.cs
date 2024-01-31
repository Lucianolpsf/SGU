using System;
using System.Collections.Generic;

namespace SGU.ORM;

public partial class Agendamento
{
    public int Id { get; set; }

    public DateTime? DtHoraAgendamento { get; set; }

    public DateTime AgendarData { get; set; }

    public byte Horario { get; set; }

    public int? Satisfacao { get; set; }

    public bool? Confirmacao { get; set; }

    public int? FkUsuarioId { get; set; }

    public int? FkServicoId { get; set; }

    public virtual Servico? FkServico { get; set; }

    public virtual Usuario? FkUsuario { get; set; }
}
