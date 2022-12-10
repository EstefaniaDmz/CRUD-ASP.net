using System;
using System.Collections.Generic;

namespace AgenciaViajes.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public bool? Estatus { get; set; }

    public int? IdUsuarioCrea { get; set; }

    public DateTime? FechaCrea { get; set; }

    public int? IdUsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<Hotel> HotelIdUsuarioCreaNavigations { get; } = new List<Hotel>();

    public virtual ICollection<Hotel> HotelIdUsuarioModificaNavigations { get; } = new List<Hotel>();

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; }

    public virtual Usuario? IdUsuarioModificaNavigation { get; set; }

    public virtual ICollection<Usuario> InverseIdUsuarioCreaNavigation { get; } = new List<Usuario>();

    public virtual ICollection<Usuario> InverseIdUsuarioModificaNavigation { get; } = new List<Usuario>();

    public virtual ICollection<Sucursal> SucursalIdUsuarioCreaNavigations { get; } = new List<Sucursal>();

    public virtual ICollection<Sucursal> SucursalIdUsuarioModificaNavigations { get; } = new List<Sucursal>();

    public virtual ICollection<Turistum> TuristumIdUsuarioCreaNavigations { get; } = new List<Turistum>();

    public virtual ICollection<Turistum> TuristumIdUsuarioModificaNavigations { get; } = new List<Turistum>();

    public virtual ICollection<Vuelo> VueloIdUsuarioCreaNavigations { get; } = new List<Vuelo>();

    public virtual ICollection<Vuelo> VueloIdUsuarioModificaNavigations { get; } = new List<Vuelo>();
}
