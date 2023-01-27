﻿using HotelLeSequelle.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelLeSequelle
{
    internal class HotelLeSequelleContext : DbContext
    {
        public HotelLeSequelleContext()
        {
        }
        public HotelLeSequelleContext(DbContextOptions<HotelLeSequelleContext> options) : base(options)
        {
        }
        public virtual DbSet<Administrator> Administrators => Set<Administrator>();

        public virtual DbSet<Reservation> Reservations => Set<Reservation>();
        public virtual DbSet<Hotel> Hotels => Set<Hotel>();
        public virtual DbSet<Customer> Customers => Set<Customer>();
        public virtual DbSet<Receptionist> Receptionists => Set<Receptionist>();
        public virtual DbSet<Waiter> Waiters => Set<Waiter>();
        public virtual DbSet<Room> Rooms => Set<Room>();
        public virtual DbSet<SideOrder> SideOrders => Set<SideOrder>();
        public virtual DbSet<SideOrderProduct> SideOrderProducts => Set<SideOrderProduct>();
        public virtual DbSet<Floor> Floors => Set<Floor>();
        public virtual DbSet<Product> Products => Set<Product>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Hotellet;Trusted_Connection=True; ");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasAlternateKey(p => p.UserName);
            modelBuilder.Entity<Reservation>().HasOne(r => r.Room)
                .WithMany(r => r.Reservations).HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>().HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(k => k.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Receptionist>().HasMany(r => r.Reservations).WithOne(rv => rv.Receptionist).HasForeignKey(rv => rv.ReservationId).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<SideOrder>().HasOne(t => t.Reservation).WithMany(b => b.SideOrders).HasForeignKey(b => b.ReservationId).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<SideOrder>().HasOne(t => t.Staff).WithMany(p => p.SideOrders).HasForeignKey(p => p.StaffId).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Room>().HasOne(r => r.Floor).WithMany(v => v.Rooms).HasForeignKey(v => v.FloorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
