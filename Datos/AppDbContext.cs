using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Modelos;

namespace rknRallySlotApp.Datos
{
    public class AppDbContext : DbContext
    {
        // Le decimos a EF Core qué tablas mapear en SQLite basándose en nuestros modelos
        public DbSet<Campeonato> Campeonatos { get; set; } = null!;
        public DbSet<Coche> Coches { get; set; } = null!;
        public DbSet<Inscripcion> Inscripciones { get; set; } = null!;
        public DbSet<Piloto> Pilotos { get; set; } = null!;
        public DbSet<Prueba> Pruebas { get; set; } = null!;
        public DbSet<TiempoTramo> TiemposTramos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura el nombre del archivo de base de datos local
            optionsBuilder.UseSqlite(Properties.Settings.Default.CadenaConexion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // REGLA 1: Campeonato -> Nombre obligatorio y único
            modelBuilder.Entity<Campeonato>(entity =>
            {
                entity.Property(c => c.Nombre)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasIndex(c => c.Nombre)
                      .IsUnique();
            });

            // REGLA 2: Piloto -> Nombre y Abreviado obligatorios, Abreviado único
            modelBuilder.Entity<Piloto>(entity =>
            {
                entity.Property(p => p.Nombre)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasIndex(p => p.Nombre)
                      .IsUnique();

                entity.Property(p => p.Abreviado)
                      .IsRequired()
                      .HasMaxLength(3);

                entity.HasIndex(p => p.Abreviado)
                      .IsUnique();
            });

            // REGLA 3: Prueba -> Todos obligatorios y Nombre único PARA ESE campeonato
            modelBuilder.Entity<Prueba>(entity =>
            {
                entity.Property(p => p.Nombre).IsRequired();
                entity.Property(p => p.NumEtapas).IsRequired();
                entity.Property(p => p.TramosPorEtapa).IsRequired();
                entity.Property(p => p.TiempoMaximo).IsRequired();
                entity.Property(p => p.IdCampeonato).IsRequired();

                // Índice compuesto: El nombre no se puede repetir dentro del mismo campeonato
                entity.HasIndex(p => new { p.IdCampeonato, p.Nombre }).IsUnique();
            });

            // REGLA 4: Inscripcion -> Atributos obligatorios y Dorsal único PARA ESA prueba
            modelBuilder.Entity<Inscripcion>(entity =>
            {
                entity.Property(i => i.IdPrueba).IsRequired();
                entity.Property(i => i.IdPiloto).IsRequired();
                entity.Property(i => i.Dorsal).IsRequired();
                entity.Property(i => i.Categoria).IsRequired();

                // Índice compuesto: No puede haber dos dorsales iguales en la misma prueba
                entity.HasIndex(i => new { i.IdPrueba, i.Dorsal }).IsUnique();
            });

            // REGLA 5: TiempoTramo -> Llave primaria compuesta por tres campos
            modelBuilder.Entity<TiempoTramo>(entity =>
            {
                entity.HasKey(t => new { t.IdInscripcion, t.Etapa, t.Tramo });
                entity.Property(t => t.Tiempo).IsRequired();
            });
        }
    }
}
