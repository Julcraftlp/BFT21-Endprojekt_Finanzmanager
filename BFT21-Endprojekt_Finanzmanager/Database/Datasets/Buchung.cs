using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database.Datasets
{
    internal class Buchung
    {
        public int Id { get; set; }
        public short BuchungsTyp { get; set; }
        public double NettoSum { get; set; }
        public double BruttoSum { get; set; }
        public Konto EigKonto { get; set; } = null!;
        public Konto ExtKonto { get; set; }
        public List<BuchungsPosition> Positionen { get; set; } = null!;
    }
}
