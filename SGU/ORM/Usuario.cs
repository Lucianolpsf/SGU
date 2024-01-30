using System;
using System.Collections.Generic;

namespace SGU.ORM;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public string? Telefone { get; set; }

    public string? TipoUsuario { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; } = new List<Agendamento>();

    public virtual ICollection<Comentario> Comentarios { get; } = new List<Comentario>();
}
