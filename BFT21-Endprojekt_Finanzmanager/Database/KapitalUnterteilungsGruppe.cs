using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database
{
    internal class KapitalUnterteilungsGruppe
    {
        public int Id { get; set; }
        public Konto konto { get; set; }
        //DigitalMoney
        public double betrag {  get; set; }
        //AnalogMoney
        public int einct { get; set; }
        public int zweict {  get; set; }
        public int fuenfct { get; set; }
        public int zehnct {  get; set; }
        public int zwanzigct {  get; set; }
        public int fuenfzigct { get; set; }
        public int eineuro {  get; set; }
        public int zweieuro {  get; set; }
        public int fuenfeuro {  get; set; }
        public int zehneuro {  get; set; }
        public int zwanzigeuro { get; set; }
        public int fuenfzigeuro { get; set; }
        public int einhuderteuro {  get; set; }
    }
}
