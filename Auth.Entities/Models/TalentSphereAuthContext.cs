using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Auth.Entities.Models;

public partial class TalentSphereAuthContext : DbContext
{
    public TalentSphereAuthContext(DbContextOptions<TalentSphereAuthContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CodigoValidacion).HasMaxLength(50);
            entity.Property(e => e.Contrasenna).HasMaxLength(50);
            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.ExpiracionCodigo)
                .HasDefaultValueSql("'0'")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaDesactivacion)
                .HasDefaultValueSql("'0'")
                .HasColumnType("datetime");
            entity.Property(e => e.NumeroDocumento).HasMaxLength(50);
            entity.Property(e => e.Role).HasColumnType("int(50)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
