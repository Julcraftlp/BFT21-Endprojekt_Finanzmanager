using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database.Datasets
{
    internal class BuchungsPosition
    {
        public int Id { get; set; }
        public Buchung Buchung { get; set; }
        public int Position { get; set; } = 0!;
        public PositionsTyp PositionsTyp { get; set; }
        public string Text { get; set; }
        public double BPPU { get; set; }
        public int Amt {  get; set; }
        public double NettoPreis { get; set; }
        public double BruttoPreis { get; set; }
    }
}
