using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Back_prueba.Models;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Moneda092023> Moneda092023s { get; set; }

    public virtual DbSet<Sucursal092023> Sucursal092023s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ins-dllo-test-01.public.33e082952ab4.database.windows.net,3342;Database=TestDB;User Id=prueba;Password=pruebaconcepto;Trusted_Connection=False;Encrypt=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Moneda092023>(entity =>
        {
            entity.HasKey(e => e.CodigoMoneda).HasName("PK__Moneda_0__CBA9FD104E9C0982");

            entity.ToTable("Moneda_092023");

            entity.Property(e => e.CodigoMoneda).HasColumnName("Codigo_Moneda");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });       

        modelBuilder.Entity<Sucursal092023>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Sucursal__06370DAD3246908E");

            entity.ToTable("Sucursal_092023");

            entity.Property(e => e.CodigoMoneda).HasColumnName("Codigo_Moneda");
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.EsBorrado)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Es_Borrado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.Identificacion).HasMaxLength(50);

            entity.HasOne(d => d.CodigoMonedaNavigation).WithMany(p => p.Sucursal092023s)
                .HasForeignKey(d => d.CodigoMoneda)
                .HasConstraintName("fk_moneda");
        });        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
