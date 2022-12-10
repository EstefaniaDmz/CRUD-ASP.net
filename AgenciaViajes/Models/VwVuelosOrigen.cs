using System;
using System.Collections.Generic;

namespace AgenciaViajes.Models;

public partial class VwVuelosOrigen
{
    public int IdVuelo { get; set; }

    public string País { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Ciudad { get; set; } = null!;
}
