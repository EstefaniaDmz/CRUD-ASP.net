using System;
using System.Collections.Generic;

namespace AgenciaViajes.Models;

public partial class Hotel
{
    public int IdHotel { get; set; }

    public string Telefono { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Calle { get; set; } = null!;

    public string Colonia { get; set; } = null!;

    public string Cp { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Pais { get; set; } = null!;

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
