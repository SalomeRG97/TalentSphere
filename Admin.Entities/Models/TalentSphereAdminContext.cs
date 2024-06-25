using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Admin.Entities.Models;

public partial class TalentSphereAdminContext : DbContext
{
    public TalentSphereAdminContext(DbContextOptions<TalentSphereAdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arl> Arls { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Ceco> Cecos { get; set; }

    public virtual DbSet<ContratosLaborale> ContratosLaborales { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Ep> Eps { get; set; }

    public virtual DbSet<FileRecord> FileRecords { get; set; }

    public virtual DbSet<FondosPensione> FondosPensiones { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TiposContrato> TiposContratos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ARL__3214EC07A9AE492D");

            entity.ToTable("ARL");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cargos__3214EC07D950C55C");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ceco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CECO__3214EC0762C14C77");

            entity.ToTable("CECO");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ContratosLaborale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contrato__3214EC07CB6F3CEF");

            entity.Property(e => e.Arlid).HasColumnName("ARLId");
            entity.Property(e => e.Epsid).HasColumnName("EPSId");
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.HojaVidaRef)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Salario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SoportesRef)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Arl).WithMany(p => p.ContratosLaborales)
                .HasForeignKey(d => d.Arlid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContratosLaborales_ARL");

            entity.HasOne(d => d.Cargo).WithMany(p => p.ContratosLaborales)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContratosLaborales_Cargos");

            entity.HasOne(d => d.Empleado).WithMany(p => p.ContratosLaborales)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContratosLaborales_Empleados");

            entity.HasOne(d => d.Eps).WithMany(p => p.ContratosLaborales)
                .HasForeignKey(d => d.Epsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContratosLaborales_EPS");

            entity.HasOne(d => d.FondoPension).WithMany(p => p.ContratosLaborales)
                .HasForeignKey(d => d.FondoPensionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContratosLaborales_FondosPensiones");

            entity.HasOne(d => d.Servicio).WithMany(p => p.ContratosLaborales)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContratosLaborales_Servicios");

            entity.HasOne(d => d.TipoContrato).WithMany(p => p.ContratosLaborales)
                .HasForeignKey(d => d.TipoContratoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContratosLaborales_TiposContratos");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3214EC078AD2E59B");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CorreoEmpresarial)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CorreoPersonal)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Guid)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EPS__3214EC074463598B");

            entity.ToTable("EPS");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FileRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FileReco__3214EC07069133E0");

            entity.ToTable("FileRecord");

            entity.Property(e => e.ContentType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Guid)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ruta)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FondosPensione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FondosPe__3214EC077BCC50F2");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Servicio__3214EC079842094C");

            entity.Property(e => e.Cecoid).HasColumnName("CECOId");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Ceco).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.Cecoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicios_CECO");
        });

        modelBuilder.Entity<TiposContrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TiposCon__3214EC07C610DC5C");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
