using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database.Datasets
{
    internal class Invoice
    {
        public int Id { get; set; }
        public short BuchungsTyp { get; set; }
        public double NettoSum { get; set; }
        public double BruttoSum { get; set; }
        public Account EigKonto { get; set; } = null!;
        public Account? ExtKonto { get; set; }
        public ICollection<InvoicePosition> Positionen { get; set; } = null!;
    }
}
