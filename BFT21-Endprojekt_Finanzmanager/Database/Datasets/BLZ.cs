using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database.Datasets
{
    internal class BLZ
    {
        public int Id {  get; set; }
        public int Nummer {  get; set; }
        public string Bank { get; set; } = null!;

    }
}
