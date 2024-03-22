using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFT21_Endprojekt_Finanzmanager.Database.Datasets;

namespace BFT21_Endprojekt_Finanzmanager.Database
{
    internal class DatabaseDefiner : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Konto> Konten { get; set; } = null!;
        public DbSet<Laendercode> Laendercodes {  get; set; } = null!;
        public DbSet<BLZ> BankLeitZahl {  get; set; } = null!;
        public DbSet<Buchung> Buchungen { get; set; } = null!;
        public DbSet<BuchungsPosition> BuchungsPositionen {  get; set; } = null!;
        public DbSet<PositionsTyp> PositionsTypen { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Konto>().HasKey(k => k.Id);
            modelBuilder.Entity<Laendercode>().HasKey(l => l.Id);
            modelBuilder.Entity<BLZ>().HasKey(blz => blz.Id);
            modelBuilder.Entity<Buchung>().HasKey(b => b.Id);
            modelBuilder.Entity<BuchungsPosition>().HasKey(bp => bp.Id);
            modelBuilder.Entity<PositionsTyp>().HasKey(pt => pt.Id);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($@"Data Source=C:\Users\julia\Documents\Datenbanken\EndprojektFinanzmanager\Database.db");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
