using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leverandører.Models
{
    public class Leverandør
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Postnummer { get; set; }
        public string Kontaktperson { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}
