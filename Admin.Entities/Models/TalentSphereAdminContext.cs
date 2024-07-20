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

    public virtual DbSet<BacklogsEvent> BacklogsEvents { get; set; }

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
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ARL");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<BacklogsEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("BacklogsEvent");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompletedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EventType).HasColumnType("int(11)");
            entity.Property(e => e.Json).IsRequired();
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Ceco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CECO");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<ContratosLaborale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Arlid, "ARLId");

            entity.HasIndex(e => e.CargoId, "CargoId");

            entity.HasIndex(e => e.Epsid, "EPSId");

            entity.HasIndex(e => e.EmpleadoId, "EmpleadoId");

            entity.HasIndex(e => e.FondoPensionId, "FondoPensionId");

            entity.HasIndex(e => e.ServicioId, "ServicioId");

            entity.HasIndex(e => e.TipoContratoId, "TipoContratoId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Arlid)
                .HasColumnType("int(11)")
                .HasColumnName("ARLId");
            entity.Property(e => e.CargoId).HasColumnType("int(11)");
            entity.Property(e => e.EmpleadoId).HasColumnType("int(11)");
            entity.Property(e => e.Epsid)
                .HasColumnType("int(11)")
                .HasColumnName("EPSId");
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.FondoPensionId).HasColumnType("int(11)");
            entity.Property(e => e.HojaVidaRef).HasMaxLength(255);
            entity.Property(e => e.Salario).HasPrecision(10);
            entity.Property(e => e.ServicioId).HasColumnType("int(11)");
            entity.Property(e => e.SoportesRef).HasMaxLength(255);
            entity.Property(e => e.TipoContratoId).HasColumnType("int(11)");

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
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Apellidos)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.ContactoEmergencia).HasColumnType("bigint(20)");
            entity.Property(e => e.CorreoEmpresarial)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.CorreoPersonal)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Guid)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.NumeroDocumento)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Telefono).HasColumnType("bigint(20)");
            entity.Property(e => e.TelefonoContactoEmergencia).HasColumnType("bigint(20)");
            entity.Property(e => e.TipoDocumento).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Ep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("EPS");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<FileRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("FileRecord");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ContentType).HasColumnType("int(11)");
            entity.Property(e => e.File).HasColumnType("blob");
            entity.Property(e => e.Guid)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.IdentificadorEmpleado)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Ruta)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<FondosPensione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Cecoid, "CECOId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cecoid)
                .HasColumnType("int(11)")
                .HasColumnName("CECOId");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.Ceco).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.Cecoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicios_CECO");
        });

        modelBuilder.Entity<TiposContrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
