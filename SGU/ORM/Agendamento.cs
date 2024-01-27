﻿using System;
using System.Collections.Generic;

namespace SGU.ORM;

public partial class Agendamento
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public DateTime? DtAgendamento { get; set; }

    public int? FkServicoId { get; set; }

    public int? FkUsuarioId { get; set; }
}
