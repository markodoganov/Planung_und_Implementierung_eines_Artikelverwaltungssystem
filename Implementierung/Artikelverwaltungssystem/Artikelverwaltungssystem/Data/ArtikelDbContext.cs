using Microsoft.EntityFrameworkCore;
using Artikelverwaltungssystem.Models;

namespace Artikelverwaltungssystem.Data
{
    public class ArtikelDbContext : DbContext
    {
        public DbSet<Artikel> Artikel { get; set; }

        public DbSet<Abteilung> Abteilungen { get; set; }

        public DbSet<Verbrauchsart> Verbrauchsarten { get; set; }

        public DbSet<Verbrauchsbuchung> Verbrauchsbuchungen { get; set; }

        public DbSet<Historie> Historien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=artikelverwaltung.db");
        }
    }
}