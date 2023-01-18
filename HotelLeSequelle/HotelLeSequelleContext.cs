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
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Receptionist> Receptionists { get; set; }
        public virtual DbSet<Waiter> Waiters { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<SideOrder> SideOrders { get; set; }
        //public virtual DbSet<SideOrderProduct> SideOrderProducts { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Product> Products { get; set; }

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
