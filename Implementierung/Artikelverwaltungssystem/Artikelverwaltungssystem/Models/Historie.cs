using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artikelverwaltungssystem.Models
{
    public class Historie
    {
        [Key]
        public int HistorienID { get; set; }

        public int ArtikelID { get; set; }

        public string AlteAbteilung { get; set; }

        public string NeueAbteilung { get; set; }

        public DateTime GeaendertAm { get; set; }
    }
}
