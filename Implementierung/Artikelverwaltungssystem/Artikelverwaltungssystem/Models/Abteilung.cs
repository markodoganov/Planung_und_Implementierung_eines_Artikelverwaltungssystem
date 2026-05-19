using System.ComponentModel.DataAnnotations;

namespace Artikelverwaltungssystem.Models
{
    public class Abteilung
    {
        [Key]
        public int AbteilungsID { get; set; }

        public string Name { get; set; }
    }
}