using System;
using System.Collections.Generic;

namespace SGU.ORM;

public partial class Comentario
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public int? FkUsuarioId { get; set; }

    public virtual Usuario? FkUsuario { get; set; }
}
