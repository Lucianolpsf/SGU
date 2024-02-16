using System;
using System.Collections.Generic;

namespace SGU.ORM;

public partial class Manutencao
{
    public int Id { get; set; }

    public string Tecnica { get; set; } = null!;

    public decimal Valor { get; set; }

    public int Prazo { get; set; }

    public int FkServico { get; set; }
}
