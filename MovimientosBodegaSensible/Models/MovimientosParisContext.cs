using Microsoft.EntityFrameworkCore;

namespace MovimientosBodegaSensible.Models;

public partial class MovimientosParisContext : DbContext
{
    public MovimientosParisContext()
    {
    }

    public MovimientosParisContext(DbContextOptions<MovimientosParisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MovimientoVenta> MovimientoVentas { get; set; }

    public virtual DbSet<Recepcion> Recepcions { get; set; }

    public virtual DbSet<Sac> Sacs { get; set; }

    public virtual DbSet<ServicioTecnico> ServicioTecnicoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovimientoVenta>(entity =>
        {
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Producto).HasMaxLength(90);
            entity.Property(e => e.Responsable).HasMaxLength(90);
            entity.Property(e => e.Sku).HasColumnName("SKU");
        });

        modelBuilder.Entity<Recepcion>(entity =>
        {
            entity.ToTable("Recepcion");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Responsable).HasMaxLength(90);
        });

        modelBuilder.Entity<Sac>(entity =>
        {
            entity.ToTable("Sac");

            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Responsable).HasMaxLength(90);
            entity.Property(e => e.Sku).HasColumnName("SKU");
            entity.Property(e => e.TipoMovimiento).HasMaxLength(60);
        });

        modelBuilder.Entity<ServicioTecnico>(entity =>
        {
            entity.ToTable("ServicioTecnico");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nguia).HasColumnName("NGuia");
            entity.Property(e => e.Producto).HasMaxLength(80);
            entity.Property(e => e.Responsable).HasMaxLength(90);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
