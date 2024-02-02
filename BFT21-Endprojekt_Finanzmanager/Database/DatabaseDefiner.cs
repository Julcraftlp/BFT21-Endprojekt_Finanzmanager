using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database
{
    internal class DatabaseDefiner : DbContext
    {
        public DbSet<Person> Personen { get; set; } = null!;
        public DbSet<Konto> Konten { get; set; } = null!;
        public DbSet<GeldZaehlung> GeldZerhlungen { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Konto>().HasKey(k => k.Id);
            modelBuilder.Entity<GeldZaehlung>().HasKey(g => g.Id);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($@"Data Source={Directory.GetCurrentDirectory()}\Database\Database.db");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
