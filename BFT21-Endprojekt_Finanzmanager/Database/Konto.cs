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
        public Person inhaber { get; set; }
        public string anzeigeName {  get; set; }
        public string kontoname { get; set; }
        public int kontoTyp { get; set; } = 0;
        // 0 = Nicht zugeordnet
        // 1 = Bargeld
        // 2 = Bankkonto
        // 3 = WebsiteGuthaben
        // 4 = CryptoWallets
        public string waerungsTyp { get; set; }
        public double kontostand {  get; set; }
        public List<KapitalUnterteilungsGruppe> KapitalUnterteilungsGruppen { get; set; }
        //1
        public string lagerort { get; set; }
        //2
        public string bank { get; set; }
        public string laendercode {  get; set; }
        public int pruefsumme {  get; set; }
        public int bankleitzahl { get; set; }
        public int kontonummer {  get; set; }
        //3
        public string webAdresse {  get; set; }
        //4
        public string walletAdress {  get; set; }

    }
}
