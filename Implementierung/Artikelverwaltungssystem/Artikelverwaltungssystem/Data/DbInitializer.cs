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
                new Artikel { Bezeichnung = "Dell Monitor U2422H", Kategorie = "Monitor", Seriennummer = "MON1001", Inventarnummer = "INV001", Status = "Aktiv", AbteilungsID = 1 },

                new Artikel { Bezeichnung = "HP LaserJet Pro", Kategorie = "Drucker", Seriennummer = "DR1002", Inventarnummer = "INV002", Status = "Aktiv", AbteilungsID = 2 },

                new Artikel { Bezeichnung = "Lenovo ThinkPad T14", Kategorie = "Laptop", Seriennummer = "LT1003", Inventarnummer = "INV003", Status = "Aktiv", AbteilungsID = 1 },

                new Artikel { Bezeichnung = "Dell Latitude 5530", Kategorie = "Laptop", Seriennummer = "LT1004", Inventarnummer = "INV004", Status = "Aktiv", AbteilungsID = 2 },

                new Artikel { Bezeichnung = "HP EliteDesk", Kategorie = "PC", Seriennummer = "PC1005", Inventarnummer = "INV005", Status = "Aktiv", AbteilungsID = 1 },

                new Artikel { Bezeichnung = "Samsung Monitor", Kategorie = "Monitor", Seriennummer = "MON1006", Inventarnummer = "INV006", Status = "Aktiv", AbteilungsID = 3 },

                new Artikel { Bezeichnung = "Canon Drucker", Kategorie = "Drucker", Seriennummer = "DR1007", Inventarnummer = "INV007", Status = "Aktiv", AbteilungsID = 2 },

                new Artikel { Bezeichnung = "Brother HL-L2375DW", Kategorie = "Drucker", Seriennummer = "DR1008", Inventarnummer = "INV008", Status = "Aktiv", AbteilungsID = 3 },

                new Artikel { Bezeichnung = "Logitech Tastatur", Kategorie = "Zubehör", Seriennummer = "ZU1009", Inventarnummer = "INV009", Status = "Aktiv", AbteilungsID = 1 },

                new Artikel { Bezeichnung = "Logitech Maus", Kategorie = "Zubehör", Seriennummer = "ZU1010", Inventarnummer = "INV010", Status = "Aktiv", AbteilungsID = 1 },

                new Artikel { Bezeichnung = "Cisco Switch", Kategorie = "Netzwerk", Seriennummer = "NW1011", Inventarnummer = "INV011", Status = "Aktiv", AbteilungsID = 1 },

                new Artikel { Bezeichnung = "FritzBox 7590", Kategorie = "Netzwerk", Seriennummer = "NW1012", Inventarnummer = "INV012", Status = "Aktiv", AbteilungsID = 1 },

                new Artikel { Bezeichnung = "HP Dockingstation", Kategorie = "Zubehör", Seriennummer = "ZU1013", Inventarnummer = "INV013", Status = "Aktiv", AbteilungsID = 2 },

                new Artikel { Bezeichnung = "Dell Webcam", Kategorie = "Zubehör", Seriennummer = "ZU1014", Inventarnummer = "INV014", Status = "Aktiv", AbteilungsID = 3 },

                new Artikel { Bezeichnung = "Lenovo ThinkCentre", Kategorie = "PC", Seriennummer = "PC1015", Inventarnummer = "INV015", Status = "Aktiv", AbteilungsID = 2 }
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