﻿// <auto-generated />
using System;
using HotelLeSequelle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    [DbContext(typeof(HotelLeSequelleContext))]
    [Migration("20230129140634_noactionconstraintbuild")]
    partial class noactionconstraintbuild
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelLeSequelle.Models.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdministratorId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdministratorId");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("CardDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Floor", b =>
                {
                    b.Property<int>("FloorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FloorId"), 1L, 1);

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("FloorId");

                    b.HasIndex("HotelId");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Hotel", b =>
                {
                    b.Property<int>("HoteliD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HoteliD"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfFloors")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebPage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HoteliD");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Receptionist", b =>
                {
                    b.Property<int>("ReceptionistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceptionistId"), 1L, 1);

                    b.Property<DateTime?>("DateOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("StreetAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReceptionistId");

                    b.ToTable("Receptionists", (string)null);
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationCustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("ReservationReceptionistId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationRoomId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("ReservationCustomerID");

                    b.HasIndex("ReservationReceptionistId");

                    b.HasIndex("ReservationRoomId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<int>("FloorId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("FloorId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.SideOrder", b =>
                {
                    b.Property<int>("SideOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SideOrderId"), 1L, 1);

                    b.Property<int>("OrderTotal")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("SideOrderReceptionistReceptionistId")
                        .HasColumnType("int");

                    b.Property<int?>("SideOrderReservationReservationId")
                        .HasColumnType("int");

                    b.Property<int?>("SideOrderWaiterWaiterId")
                        .HasColumnType("int");

                    b.HasKey("SideOrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SideOrderReceptionistReceptionistId");

                    b.HasIndex("SideOrderReservationReservationId");

                    b.HasIndex("SideOrderWaiterWaiterId");

                    b.ToTable("SideOrders");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.SideOrderProduct", b =>
                {
                    b.Property<int>("SideOrderProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SideOrderProductId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SideOrderId")
                        .HasColumnType("int");

                    b.HasKey("SideOrderProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SideOrderId");

                    b.ToTable("SideOrderProducts");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Waiter", b =>
                {
                    b.Property<int>("WaiterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WaiterId"), 1L, 1);

                    b.Property<DateTime?>("DateOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("StreetAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WaiterId");

                    b.ToTable("Waiters", (string)null);
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Floor", b =>
                {
                    b.HasOne("HotelLeSequelle.Models.Hotel", "Hotel")
                        .WithMany("Floors")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Reservation", b =>
                {
                    b.HasOne("HotelLeSequelle.Models.Customer", "ReservationCustomer")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservationCustomerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HotelLeSequelle.Models.Receptionist", "ReservationReceptionist")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservationReceptionistId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HotelLeSequelle.Models.Room", "ReservationRoom")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservationRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReservationCustomer");

                    b.Navigation("ReservationReceptionist");

                    b.Navigation("ReservationRoom");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Room", b =>
                {
                    b.HasOne("HotelLeSequelle.Models.Floor", "Floor")
                        .WithMany("Rooms")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.SideOrder", b =>
                {
                    b.HasOne("HotelLeSequelle.Models.Product", null)
                        .WithMany("SideOrders")
                        .HasForeignKey("ProductId");

                    b.HasOne("HotelLeSequelle.Models.Receptionist", "SideOrderReceptionist")
                        .WithMany("SideOrders")
                        .HasForeignKey("SideOrderReceptionistReceptionistId");

                    b.HasOne("HotelLeSequelle.Models.Reservation", "SideOrderReservation")
                        .WithMany("ReservationSideOrders")
                        .HasForeignKey("SideOrderReservationReservationId");

                    b.HasOne("HotelLeSequelle.Models.Waiter", "SideOrderWaiter")
                        .WithMany("SideOrders")
                        .HasForeignKey("SideOrderWaiterWaiterId");

                    b.Navigation("SideOrderReceptionist");

                    b.Navigation("SideOrderReservation");

                    b.Navigation("SideOrderWaiter");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.SideOrderProduct", b =>
                {
                    b.HasOne("HotelLeSequelle.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLeSequelle.Models.SideOrder", "SideOrder")
                        .WithMany("SideOrderProducts")
                        .HasForeignKey("SideOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SideOrder");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Floor", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Hotel", b =>
                {
                    b.Navigation("Floors");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Product", b =>
                {
                    b.Navigation("SideOrders");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Receptionist", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("SideOrders");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Reservation", b =>
                {
                    b.Navigation("ReservationSideOrders");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Room", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.SideOrder", b =>
                {
                    b.Navigation("SideOrderProducts");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Waiter", b =>
                {
                    b.Navigation("SideOrders");
                });
#pragma warning restore 612, 618
        }
    }
}