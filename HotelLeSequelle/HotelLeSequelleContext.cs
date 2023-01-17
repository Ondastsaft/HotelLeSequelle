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

        public virtual DbSet<Reservation> Bokningar { get; set; }
        public virtual DbSet<Hotel> Hotell { get; set; }
        public virtual DbSet<Customer> Kunder { get; set; }
        public virtual DbSet<Receptionist> Receptionister { get; set; }
        public virtual DbSet<Waiter> Servitörer { get; set; }
        public virtual DbSet<Room> Rum { get; set; }
        public virtual DbSet<SideOrder> Tilläggsbeställningar { get; set; }
        public virtual DbSet<SideOrderProduct> Tilläggsvaror { get; set; }
        public virtual DbSet<Floor> Våningar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Hotellet;Trusted_Connection=True; ");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasOne(b => b.Room).WithMany(b => b.Reservations).HasForeignKey(r => r.RoomID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>().HasOne(b => b.Customer).WithMany(b => b.Reservations).HasForeignKey(k => k.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>().HasOne(b => b.Receptionist).WithMany(r => r.Reservations).HasForeignKey(r => r.ReceptionistId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SideOrder>().HasOne(t => t.Reservation).WithMany(b => b.SideOrders).HasForeignKey(b => b.ReservationId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SideOrder>().HasOne(t => t.Staff).WithMany(p => p.SideOrders).HasForeignKey(p => p.StaffId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Room>().HasOne(r => r.Floor).WithMany(v => v.Rooms).HasForeignKey(v => v.FloorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
