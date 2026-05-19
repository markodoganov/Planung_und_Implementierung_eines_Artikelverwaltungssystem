using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artikelverwaltungssystem.Models
{
    public class Verbrauchsart
    {
        [Key]
        public int VerbrauchsartID { get; set; }

        public string Bezeichnung { get; set; }
    }
}
