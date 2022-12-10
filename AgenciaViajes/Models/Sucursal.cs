using System;
using System.Collections.Generic;

namespace AgenciaViajes.Models;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Calle { get; set; } = null!;

    public string Colonia { get; set; } = null!;

    public string Cp { get; set; } = null!;

    public int NumeroPlazas { get; set; }

    public bool? Estatus { get; set; }

    public int? IdUsuarioCrea { get; set; }

    public DateTime? FechaCrea { get; set; }

    public int? IdUsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; }

    public virtual Usuario? IdUsuarioModificaNavigation { get; set; }

    public virtual ICollection<Turistum> Turista { get; } = new List<Turistum>();
}
