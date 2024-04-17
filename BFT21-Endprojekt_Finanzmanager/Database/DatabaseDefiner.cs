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
        public DbSet<Account> Konten { get; set; } = null!;
        public DbSet<Laendercode> Laendercodes {  get; set; } = null!;
        public DbSet<BLZ> BankLeitZahl {  get; set; } = null!;
        public DbSet<Invoice> Buchungen { get; set; } = null!;
        public DbSet<InvoicePosition> BuchungsPositionen {  get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Account>()
                .HasKey(k => k.Id);
            modelBuilder.Entity<Laendercode>()
                .HasKey(l => l.Id);
            modelBuilder.Entity<BLZ>()
                .HasKey(blz => blz.Id);
            modelBuilder.Entity<Invoice>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<InvoicePosition>()
                .HasKey(bp => bp.Id);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithMany(a => a.Accounts)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Laendercode);
            modelBuilder.Entity<Account>()
                .HasOne(a => a.BankLeitZahl);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($@"Data Source={Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\source\repos\BFT21-Endprojekt_Finanzmanager\BFT21-Endprojekt_Finanzmanager\Database\Database.db");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
