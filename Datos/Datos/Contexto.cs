using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Datos.Datos;

public partial class Contexto : DbContext
{
    public Contexto()
    {
    }

    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudad { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Sucursal> Sucursal { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=anthonyjj3_PracticaAbril;User ID=anthonyjj3_PracticaAbril;Password=12345678;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Idciudad).HasName("PK__ciudad__4572846D04C0EE21");

            entity.ToTable("ciudad");

            entity.Property(e => e.Idciudad).HasColumnName("idciudad");
            entity.Property(e => e.Estadociudad).HasColumnName("estadociudad");
            entity.Property(e => e.Nombreciudad)
                .IsUnicode(false)
                .HasColumnName("nombreciudad");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persona__3213E83FBD161340");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido).IsUnicode(false);
            entity.Property(e => e.Frase).IsUnicode(false);
            entity.Property(e => e.Nombre).IsUnicode(false);
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3213E83F173FB9AE");

            entity.ToTable("productos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Idsucursal).HasName("PK__sucursal__0C87B341FFBFA620");

            entity.ToTable("sucursal");

            entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");
            entity.Property(e => e.Estadosucursal).HasColumnName("estadosucursal");
            entity.Property(e => e.Idciudad).HasColumnName("idciudad");
            entity.Property(e => e.Nombresucursal)
                .IsUnicode(false)
                .HasColumnName("nombresucursal");

            entity.HasOne(d => d.IdciudadNavigation).WithMany(p => p.Sucursal)
                .HasForeignKey(d => d.Idciudad)
                .HasConstraintName("FK_SucursalCiudad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
