using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database.Datasets
{
    internal class PositionsTyp
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Absetzbar { get; set; } = false;
        public int Steuersatz { get; set; } = 0;

    }
}
