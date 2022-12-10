using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViajes.Models;

public partial class AgenciaViajesContext : DbContext
{
    public AgenciaViajesContext()
    {
    }

    public AgenciaViajesContext(DbContextOptions<AgenciaViajesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<Turistum> Turista { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    public virtual DbSet<VwTuristaHotel> VwTuristaHotels { get; set; }

    public virtual DbSet<VwUsuario> VwUsuarios { get; set; }

    public virtual DbSet<VwVuelo> VwVuelos { get; set; }

    public virtual DbSet<VwVuelosOrigen> VwVuelosOrigens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.IdHotel).HasName("PKHotel");

            entity.ToTable("Hotel");

            entity.HasIndex(e => e.IdHotel, "IX_Hotel");

            entity.Property(e => e.IdHotel).HasColumnName("idHotel");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colonia");
            entity.Property(e => e.Cp)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cp");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Estatus)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estatus");
            entity.Property(e => e.FechaCrea)
                .HasColumnType("datetime")
                .HasColumnName("fechaCrea");
            entity.Property(e => e.FechaModifica)
                .HasColumnType("datetime")
                .HasColumnName("fechaModifica");
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.IdUsuarioModifica).HasColumnName("idUsuarioModifica");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroPlazas).HasColumnName("numeroPlazas");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.HotelIdUsuarioCreaNavigations)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .HasConstraintName("FKHotelUsuarioCrea");

            entity.HasOne(d => d.IdUsuarioModificaNavigation).WithMany(p => p.HotelIdUsuarioModificaNavigations)
                .HasForeignKey(d => d.IdUsuarioModifica)
                .HasConstraintName("FKHotelUsuarioModifica");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PKSucursal");

            entity.ToTable("Sucursal");

            entity.HasIndex(e => e.IdSucursal, "IX_Sucursal");

            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colonia");
            entity.Property(e => e.Cp)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cp");
            entity.Property(e => e.Estatus)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estatus");
            entity.Property(e => e.FechaCrea)
                .HasColumnType("datetime")
                .HasColumnName("fechaCrea");
            entity.Property(e => e.FechaModifica)
                .HasColumnType("datetime")
                .HasColumnName("fechaModifica");
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.IdUsuarioModifica).HasColumnName("idUsuarioModifica");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroPlazas).HasColumnName("numeroPlazas");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.SucursalIdUsuarioCreaNavigations)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .HasConstraintName("FKSucursalUsuarioCrea");

            entity.HasOne(d => d.IdUsuarioModificaNavigation).WithMany(p => p.SucursalIdUsuarioModificaNavigations)
                .HasForeignKey(d => d.IdUsuarioModifica)
                .HasConstraintName("FKSucursalUsuarioModifica");
        });

        modelBuilder.Entity<Turistum>(entity =>
        {
            entity.HasKey(e => e.IdTurista).HasName("PKTurista");

            entity.HasIndex(e => e.IdTurista, "IX_Turista");

            entity.Property(e => e.IdTurista).HasColumnName("idTurista");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidoMaterno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidoPaterno");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.ClaseTurista)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("claseTurista");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colonia");
            entity.Property(e => e.Cp)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cp");
            entity.Property(e => e.Estatus)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estatus");
            entity.Property(e => e.FechaCrea)
                .HasColumnType("datetime")
                .HasColumnName("fechaCrea");
            entity.Property(e => e.FechaModifica)
                .HasColumnType("datetime")
                .HasColumnName("fechaModifica");
            entity.Property(e => e.IdHotel).HasColumnName("idHotel");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.IdUsuarioModifica).HasColumnName("idUsuarioModifica");
            entity.Property(e => e.IdVuelo).HasColumnName("idVuelo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.RegimenHotel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regimenHotel");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.Turista)
                .HasForeignKey(d => d.IdHotel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTuristaHotel");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Turista)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTuristaSucursal");

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.TuristumIdUsuarioCreaNavigations)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .HasConstraintName("FKTuristaUsuarioCrea");

            entity.HasOne(d => d.IdUsuarioModificaNavigation).WithMany(p => p.TuristumIdUsuarioModificaNavigations)
                .HasForeignKey(d => d.IdUsuarioModifica)
                .HasConstraintName("FKTuristaUsuarioModifica");

            entity.HasOne(d => d.IdVueloNavigation).WithMany(p => p.Turista)
                .HasForeignKey(d => d.IdVuelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTuristaVuelo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PKUsuario");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.IdUsuario, "IX_Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidoMaterno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidoPaterno");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Estatus)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estatus");
            entity.Property(e => e.FechaCrea)
                .HasColumnType("datetime")
                .HasColumnName("fechaCrea");
            entity.Property(e => e.FechaModifica)
                .HasColumnType("datetime")
                .HasColumnName("fechaModifica");
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.IdUsuarioModifica).HasColumnName("idUsuarioModifica");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.InverseIdUsuarioCreaNavigation)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .HasConstraintName("FKUsuarioUsuarioCrea");

            entity.HasOne(d => d.IdUsuarioModificaNavigation).WithMany(p => p.InverseIdUsuarioModificaNavigation)
                .HasForeignKey(d => d.IdUsuarioModifica)
                .HasConstraintName("FKUsuarioUsuarioModifica");
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.HasKey(e => e.IdVuelo).HasName("PKVuelo");

            entity.ToTable("Vuelo");

            entity.HasIndex(e => e.IdVuelo, "IX_Vuelo");

            entity.Property(e => e.IdVuelo).HasColumnName("idVuelo");
            entity.Property(e => e.CiudadDestino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudadDestino");
            entity.Property(e => e.CiudadOrigen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudadOrigen");
            entity.Property(e => e.EstadoDestino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estadoDestino");
            entity.Property(e => e.EstadoOrigen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estadoOrigen");
            entity.Property(e => e.Estatus)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estatus");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaCrea)
                .HasColumnType("datetime")
                .HasColumnName("fechaCrea");
            entity.Property(e => e.FechaModifica)
                .HasColumnType("datetime")
                .HasColumnName("fechaModifica");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.IdUsuarioModifica).HasColumnName("idUsuarioModifica");
            entity.Property(e => e.PaisDestino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paisDestino");
            entity.Property(e => e.PaisOrigen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paisOrigen");
            entity.Property(e => e.PlazasTotales).HasColumnName("plazasTotales");

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.VueloIdUsuarioCreaNavigations)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .HasConstraintName("FKVueloUsuarioCrea");

            entity.HasOne(d => d.IdUsuarioModificaNavigation).WithMany(p => p.VueloIdUsuarioModificaNavigations)
                .HasForeignKey(d => d.IdUsuarioModifica)
                .HasConstraintName("FKVueloUsuarioModifica");
        });

        modelBuilder.Entity<VwTuristaHotel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTuristaHotel");

            entity.Property(e => e.Hotel)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Régimen)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Turista)
                .HasMaxLength(101)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwUsuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<VwVuelo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwVuelos");

            entity.Property(e => e.CiudadDestino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudadDestino");
            entity.Property(e => e.CiudadOrigen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudadOrigen");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
        });

        modelBuilder.Entity<VwVuelosOrigen>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwVuelosOrigen");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdVuelo)
                .ValueGeneratedOnAdd()
                .HasColumnName("idVuelo");
            entity.Property(e => e.País)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
