using System;
using System.Collections.Generic;

namespace AgenciaViajes.Models;

public partial class Vuelo
{
    public int IdVuelo { get; set; }

    public string CiudadOrigen { get; set; } = null!;

    public string EstadoOrigen { get; set; } = null!;

    public string PaisOrigen { get; set; } = null!;

    public string CiudadDestino { get; set; } = null!;

    public string EstadoDestino { get; set; } = null!;

    public string PaisDestino { get; set; } = null!;

    public int PlazasTotales { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    public bool? Estatus { get; set; }

    public int? IdUsuarioCrea { get; set; }

    public DateTime? FechaCrea { get; set; }

    public int? IdUsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; }

    public virtual Usuario? IdUsuarioModificaNavigation { get; set; }

    public virtual ICollection<Turistum> Turista { get; } = new List<Turistum>();
}
