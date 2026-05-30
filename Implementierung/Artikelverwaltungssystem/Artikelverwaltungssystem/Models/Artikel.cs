using System.ComponentModel.DataAnnotations;

namespace Artikelverwaltungssystem.Models
{
    public class Artikel
    {
        [Key]
        public int ArtikelID { get; set; }

        public string Bezeichnung { get; set; }

        public string Kategorie { get; set; }

        public string Seriennummer { get; set; }

        public string Inventarnummer { get; set; }

        public string Status { get; set; }

        public int AbteilungsID { get; set; }
    }
}