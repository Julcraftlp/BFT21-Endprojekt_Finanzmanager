using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database
{
    internal class Person
    {
        public int Id { get; set; }
        public string vorname { get; set; } = null!;
        public string nachname { get; set; } = null!;
        public string login { get; set; } = null!;
        public string password { get; set; }
        public List<Konto> konten {get;set; }
    }
}
