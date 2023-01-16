using HotelLeSequelle.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelLeSequelle
{
    internal class HotelLeSequelleContext : DbContext
    {
        public HotelLeSequelleContext()
        {
        }

        public HotelLeSequelleContext(DbContextOptions<HotelLeSequelleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bokning> Bokningar { get; set; }
        public virtual DbSet<Hotell> Hotell { get; set; }
        public virtual DbSet<Kund> Kunder { get; set; }
        public virtual DbSet<Receptionist> Receptionister { get; set; }
        public virtual DbSet<Servitör> Servitörer { get; set; }
        public virtual DbSet<Rum> Rum { get; set; }
        public virtual DbSet<Tilläggsbeställning> Tilläggsbeställningar { get; set; }
        public virtual DbSet<Tilläggsvara> Tilläggsvaror { get; set; }
        public virtual DbSet<Våning> Våningar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Hotellet;Trusted_Connection=True; ");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bokning>().HasOne(b => b.Rum).WithMany(b => b.Boknings).HasForeignKey(r => r.RumId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Bokning>().HasOne(b => b.Kund).WithMany(b => b.Boknings).HasForeignKey(k => k.KundId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Bokning>().HasOne(b => b.Receptionist).WithMany(r => r.Bokningar).HasForeignKey(r => r.ReceptionistId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tilläggsbeställning>().HasOne(t => t.Bokning).WithMany(b => b.Tilläggsbeställnings).HasForeignKey(b => b.BokningsId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tilläggsbeställning>().HasOne(t => t.Personal).WithMany(p => p.Tilläggsbeställningar).HasForeignKey(p => p.PersonalId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Rum>().HasOne(r => r.Våning).WithMany(v => v.Rum).HasForeignKey(v => v.VåningsId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
