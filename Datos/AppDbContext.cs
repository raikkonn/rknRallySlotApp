using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Modelos;

namespace rknRallySlotApp.Datos;

public class AppDbContext : DbContext
{
    // ==========================================
    #region SQLite Mapeo Tablas

    public DbSet<Campeonato> Campeonatos { get; set; } = null!;
    public DbSet<Categoria> Categorias { get; set; } = null!;
    public DbSet<Coche> Coches { get; set; } = null!;
    public DbSet<Inscripcion> Inscripciones { get; set; } = null!;
    public DbSet<Piloto> Pilotos { get; set; } = null!;
    public DbSet<Prueba> Pruebas { get; set; } = null!;
    public DbSet<Crono> Cronos { get; set; } = null!;

    #endregion
    // ==========================================

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configura nombre archivo DB local
        optionsBuilder.UseSqlite(Properties.Settings.Default.DbConexString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ==========================================
        // REGLA: Campeonato -> Nombre obligatorio y único
        // ==========================================
        modelBuilder.Entity<Campeonato>(entity =>
        {
            entity.Property(c => c.Nombre)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.HasIndex(c => c.Nombre)
                  .IsUnique();
        });

        // ==========================================
        // REGLA: Categoria
        // ==========================================
        modelBuilder.Entity<Categoria>(entity =>
        {
            // Nombre obligatorio
            entity.Property(c => c.Nombre)
                  .IsRequired()
                  .HasMaxLength(30);

            // Índice ÚNICO en toda la tabla para el Nombre
            entity.HasIndex(c => c.Nombre)
                  .IsUnique();
        });

        // ==========================================
        // REGLA: Coche -> Modelo obligatorio
        // ==========================================
        modelBuilder.Entity<Coche>(entity =>
        {
            entity.Property(c => c.Modelo)
                  .IsRequired()
                  .HasMaxLength(30);

            entity.Property(c => c.Marca)
                  .HasMaxLength(25);
        });

        // ==========================================
        // REGLA: Inscripcion -> Atributos obligatorios, Dorsal único PARA ESA prueba y FKs explícitas
        // ==========================================
        modelBuilder.Entity<Inscripcion>(entity =>
        {
            entity.Property(i => i.IdPrueba)
                  .IsRequired();

            entity.Property(i => i.IdPiloto)
                  .IsRequired();

            entity.Property(i => i.IdCoche)
                  .IsRequired();

            entity.Property(i => i.IdCategoria)
                  .IsRequired();

            entity.Property(i => i.Dorsal)
                  .IsRequired();

            // Índice compuesto: No puede haber dos dorsales iguales en la misma prueba
            entity.HasIndex(i => new { i.IdPrueba, i.Dorsal })
                  .IsUnique();

            // Relaciones explícitas para evitar columnas duplicadas en la BD
            entity.HasOne(i => i.Prueba)
                  .WithMany(p => p.Inscripciones)
                  .HasForeignKey(i => i.IdPrueba)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(i => i.Piloto)
                  .WithMany(p => p.Inscripciones)
                  .HasForeignKey(i => i.IdPiloto)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(i => i.Coche)
                  .WithMany(c => c.Inscripciones)
                  .HasForeignKey(i => i.IdCoche)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(i => i.Categoria)
                  .WithMany(c => c.Inscripciones)
                  .HasForeignKey(i => i.IdCategoria)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // ==========================================
        // REGLA: Piloto -> Nombre y Alias obligatorios, Nombre y Alias único
        // ==========================================
        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.Property(p => p.Nombre)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.HasIndex(p => p.Nombre)
                  .IsUnique();

            entity.Property(p => p.Alias)
                  .IsRequired()
                  .HasMaxLength(3);

            entity.HasIndex(p => p.Alias)
                  .IsUnique();

            entity.Property(p => p.Escuderia)
                  .HasMaxLength(30);
        });

        // ==========================================
        // REGLA: Prueba -> Nombre único PARA ESE campeonato y FK explícita
        // ==========================================
        modelBuilder.Entity<Prueba>(entity =>
        {
            entity.Property(p => p.Nombre)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(p => p.NumEtapas)
                  .IsRequired();

            entity.Property(p => p.TramosPorEtapa)
                  .IsRequired();

            entity.Property(p => p.TiempoMaximo)
                  .IsRequired();

            entity.Property(p => p.IdCampeonato)
                  .IsRequired();

            entity.Property(p => p.PowerStage)
                  .HasMaxLength(30)
                  .IsRequired(false);

            // Índice compuesto: El nombre no se puede repetir dentro del mismo campeonato
            entity.HasIndex(p => new { p.IdCampeonato, p.Nombre })
                  .IsUnique();

            // Relación explícita con Campeonato
            entity.HasOne(p => p.Campeonato)
                  .WithMany(c => c.Pruebas) 
                  .HasForeignKey(p => p.IdCampeonato)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ==========================================
        // REGLA: Crono -> Clave primaria compuesta por tres campos
        // ==========================================
        modelBuilder.Entity<Crono>(entity =>
        {
            // Clave primaria compuesta (IdInscripcion + Etapa + Tramo)
            entity.HasKey(c => new { c.IdInscripcion, c.Etapa, c.Tramo });
            entity.Property(c => c.CronoMS).IsRequired();

            // Relación con Inscripcion mapeando explícitamente la FK
            entity.HasOne(c => c.Inscripcion)
                  .WithMany(i => i.Cronos)
                  .HasForeignKey(c => c.IdInscripcion)
                  .OnDelete(DeleteBehavior.Cascade); // Si se elimina la inscripción, se borran sus tiempos
        });
    }
}
