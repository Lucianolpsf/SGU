using System;
using System.Collections.Generic;

namespace SGU.ORM;

public partial class TipoServico
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Servico> Servicos { get; } = new List<Servico>();
}
