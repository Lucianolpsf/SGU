using System;
using System.Collections.Generic;

namespace SGU.ORM;

public partial class Comentario
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
