using System;
using System.Collections.Generic;

namespace AgenciaViajes.Models;

public partial class VwUsuario
{
    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;
}
