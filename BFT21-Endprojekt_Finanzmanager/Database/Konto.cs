using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database
{
    internal class Konto
    {
        public int Id { get; set; }
        public Person Inhaber { get; set; } = null!;
        public string AnzeigeName {  get; set; } = null!;
        public string Kontoname { get; set; } = null!;
        public int KontoTyp { get; set; } = 0;
        // 0 = Nicht zugeordnet
        // 1 = Bargeld
        // 2 = Bankkonto
        // 3 = WebsiteGuthaben
        // 4 = CryptoWallets
        public string WaerungsTyp { get; set; } = null!;
        public double Kontostand { get; set; } = 0.0;
        public List<KapitalUnterteilungsGruppe> KapitalUnterteilungsGruppen { get; set; }
        //1/2
        public string Bank { get; set; }
        //2
        public string Laendercode {  get; set; }
        public int Pruefsumme {  get; set; }
        public int Bankleitzahl { get; set; }
        public int Kontonummer {  get; set; }
        //3/4
        public string WebAdresse {  get; set; }

    }
}
