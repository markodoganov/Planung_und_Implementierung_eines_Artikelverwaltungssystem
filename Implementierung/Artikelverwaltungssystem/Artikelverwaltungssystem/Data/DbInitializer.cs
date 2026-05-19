using System.Linq;
using Artikelverwaltungssystem.Models;

namespace Artikelverwaltungssystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ArtikelDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Abteilungen.Any())
                return;

            var abteilungen = new Abteilung[]
            {
                new Abteilung { Name = "IT" },
                new Abteilung { Name = "Verwaltung" },
                new Abteilung { Name = "Buchhaltung" }
            };

            context.Abteilungen.AddRange(abteilungen);
            context.SaveChanges();

            var artikel = new Artikel[]
            {
                new Artikel
                {
                    Bezeichnung = "Dell Monitor",
                    Kategorie = "Monitor",
                    Seriennummer = "DM12345",
                    Inventarnummer = "INV001",
                    Status = "Aktiv",
                    AbteilungsID = 1
                },
                new Artikel
                {
                    Bezeichnung = "HP LaserJet Drucker",
                    Kategorie = "Drucker",
                    Seriennummer = "HP67890",
                    Inventarnummer = "INV002",
                    Status = "Aktiv",
                    AbteilungsID = 2
                }
            };

            context.Artikel.AddRange(artikel);
            context.SaveChanges();

            var verbrauchsarten = new Verbrauchsart[]
            {
                new Verbrauchsart { Bezeichnung = "HP 305 Schwarz" },
                new Verbrauchsart { Bezeichnung = "Canon Toner 054" }
            };

            context.Verbrauchsarten.AddRange(verbrauchsarten);
            context.SaveChanges();
        }
    }
}