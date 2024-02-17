using System;
using System.Collections.Generic;

namespace SGU.ORM;

public partial class ViewAgendamento
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public DateTime AgendarData { get; set; }

    public DateTime Horario { get; set; }

    public string? Tecnica { get; set; }

    public double? Valor { get; set; }

    public bool? Confirmacao { get; set; }

    public int Expr1 { get; set; }
}
