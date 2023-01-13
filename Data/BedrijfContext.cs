using GeoProfs.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoProfs.Data
{
    public class BedrijfContext : DbContext
    {
        public BedrijfContext(DbContextOptions<BedrijfContext> options) : base(options)
        {

        }

        public DbSet<Verlofaanvraag> Verlofaanvraagen { get; set; }
        public DbSet<Werknemer> Werknemers { get; set; }
        public DbSet<Functie> Functies { get; set; }
        public DbSet<Rapport> Rapporten { get; set; }
        public DbSet<Afdeling> Afdelingen { get; set; }

        // Make the tables with singular names in the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Verlofaanvraag>().ToTable("Verlofaanvraag");
            modelBuilder.Entity<Werknemer>().ToTable("Werknemer");
            modelBuilder.Entity<Functie>().ToTable("Functie");
            modelBuilder.Entity<Rapport>().ToTable("Rapport");
            modelBuilder.Entity<Afdeling>().ToTable("Afdeling");
        }
    }
}
