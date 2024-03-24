using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database.Datasets
{
    internal class Konto
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Betrag { get; set; } = 0.0;
        public bool KontoTyp { get; set; }
        public string TF1 { get; set; } = null!;
        public Laendercode Laendercode { get; set; }
        public int Kontrollsumme { get; set; }
        public BLZ BankLeitZahl { get; set; }
        public int KontoNummer { get; set; }
        public DateOnly Gültigkeit { get; set; }
        

    }
}
