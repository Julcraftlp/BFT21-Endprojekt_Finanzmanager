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
        public string Vorname { get; set; } = null!;
        public string Nachname { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = "";
        public List<Konto> Konten {get;set; }
    }
}
