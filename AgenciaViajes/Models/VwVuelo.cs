using System;
using System.Collections.Generic;

namespace AgenciaViajes.Models;

public partial class VwVuelo
{
    public string CiudadOrigen { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    public string CiudadDestino { get; set; } = null!;
}
