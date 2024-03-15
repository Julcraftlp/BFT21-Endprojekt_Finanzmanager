using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database.Datasets
{
    internal class Laendercode
    {
        public int Id { get; set; }
        public string Kürzel { get; set; } = null!;
        public string Land { get; set; } = null!;
    }
}
