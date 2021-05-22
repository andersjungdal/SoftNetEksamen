using Kategorier.Models;
using Leverandører.Models;

namespace Produkter.Models
{
    public class Produkt
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public string Enhed { get; set; }
        public string MængdeIPakningen { get; set; }
        public int Pris { get; set; }
        public Kategori Kategori { get; set; }
        public int AntalPåLager { get; set; }
        public Leverandør Leverandør { get; set; }
    }
}