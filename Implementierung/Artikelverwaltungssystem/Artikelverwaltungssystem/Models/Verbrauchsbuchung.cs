using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artikelverwaltungssystem.Models
{
    public class Verbrauchsbuchung
    {
        [Key]
        public int VerbrauchsID { get; set; }

        public int VerbrauchsartID { get; set; }

        public int AbteilungsID { get; set; }

        public int Menge { get; set; }

        public DateTime VerwendetAm { get; set; }
    }
}
