using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database.Datasets
{
    internal class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime LockedUntil { get; set; }
        public ICollection<Invoice>? Buchungen { get; set; }
        public ICollection<Account>? Accounts { get; set; }
    }
}
