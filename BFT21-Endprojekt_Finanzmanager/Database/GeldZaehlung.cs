using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database
{
    internal class GeldZaehlung
    {
        public int Id { get; set; }
        public Konto Konto { get; set; } = null!;
        //AnalogMoney
        public int Einct { get; set; } = 0;
        public int Zweict {  get; set; } = 0;
        public int Fuenfct { get; set; } = 0;
        public int Zehnct {  get; set; } = 0;
        public int Zwanzigct {  get; set; } = 0;
        public int Fuenfzigct { get; set; } = 0;
        public int Eineuro {  get; set; } = 0;
        public int Zweieuro {  get; set; } = 0;
        public int Fuenfeuro {  get; set; } = 0;
        public int Zehneuro {  get; set; } = 0;
        public int Zwanzigeuro { get; set; } = 0;
        public int Fuenfzigeuro { get; set; } = 0;
        public int Einhuderteuro {  get; set; } = 0;
    }
}
