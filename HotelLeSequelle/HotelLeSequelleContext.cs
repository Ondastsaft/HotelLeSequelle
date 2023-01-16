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
            modelBuilder.Entity<>().HasOne
        }


    }
}
