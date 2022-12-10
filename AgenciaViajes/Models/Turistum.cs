using System;
using System.Collections.Generic;

namespace AgenciaViajes.Models;

public partial class Turistum
{
    public int IdTurista { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Calle { get; set; } = null!;

    public string Colonia { get; set; } = null!;

    public string Cp { get; set; } = null!;

    public int IdHotel { get; set; }

    public string RegimenHotel { get; set; } = null!;

    public int IdSucursal { get; set; }

    public int IdVuelo { get; set; }

    public string ClaseTurista { get; set; } = null!;

    public bool? Estatus { get; set; }

    public int? IdUsuarioCrea { get; set; }

    public DateTime? FechaCrea { get; set; }

    public int? IdUsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual Hotel IdHotelNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; }

    public virtual Usuario? IdUsuarioModificaNavigation { get; set; }

    public virtual Vuelo IdVueloNavigation { get; set; } = null!;
}
