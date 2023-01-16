﻿// <auto-generated />
using System;
using HotelLeSequelle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    [DbContext(typeof(HotelLeSequelleContext))]
    partial class HotelLeSequelleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelLeSequelle.Models.Bokning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BokandePersonalId")
                        .HasColumnType("int");

                    b.Property<int>("BokatRumId")
                        .HasColumnType("int");

                    b.Property<int>("HotellId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IncheckningsDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KundId")
                        .HasColumnType("int");

                    b.Property<int?>("ReceptionistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UtcheckningsDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BokandePersonalId");

                    b.HasIndex("BokatRumId");

                    b.HasIndex("HotellId");

                    b.HasIndex("KundId");

                    b.HasIndex("ReceptionistId");

                    b.ToTable("Bokningar");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Hotell", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AntalRum")
                        .HasColumnType("int");

                    b.Property<int>("AntalVåningar")
                        .HasColumnType("int");

                    b.Property<string>("Epost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GatuAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hemsida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostOrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefonnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotell");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Kund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Efternamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Epost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Förnamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gatuadress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kortuppgifter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationalitet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefonnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kunder");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Personal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Anställningsdatum")
                        .HasColumnType("int");

                    b.Property<int>("Anställningsnummer")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Efternamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Epost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Förnamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gatuadress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lösenord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationalitet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefonnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personal");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Personal");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Rum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RummetsVåningId")
                        .HasColumnType("int");

                    b.Property<int>("VåningsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RummetsVåningId");

                    b.ToTable("Rum");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Tilläggsbeställning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BokningId")
                        .HasColumnType("int");

                    b.Property<int>("BokningsId")
                        .HasColumnType("int");

                    b.Property<int>("OrderTotal")
                        .HasColumnType("int");

                    b.Property<int>("PersonalId")
                        .HasColumnType("int");

                    b.Property<int?>("ReceptionistId")
                        .HasColumnType("int");

                    b.Property<int?>("ServitörId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BokningId");

                    b.HasIndex("PersonalId");

                    b.HasIndex("ReceptionistId");

                    b.HasIndex("ServitörId");

                    b.ToTable("Tilläggsbeställningar");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Tilläggsvara", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pris")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tilläggsvaror");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Våning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HotellId")
                        .HasColumnType("int");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotellId");

                    b.ToTable("Våningar");
                });

            modelBuilder.Entity("TilläggsbeställningTilläggsvara", b =>
                {
                    b.Property<int>("TilläggsbeställningarId")
                        .HasColumnType("int");

                    b.Property<int>("TilläggsvarorId")
                        .HasColumnType("int");

                    b.HasKey("TilläggsbeställningarId", "TilläggsvarorId");

                    b.HasIndex("TilläggsvarorId");

                    b.ToTable("TilläggsbeställningTilläggsvara");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Receptionist", b =>
                {
                    b.HasBaseType("HotelLeSequelle.Models.Personal");

                    b.HasDiscriminator().HasValue("Receptionist");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Servitör", b =>
                {
                    b.HasBaseType("HotelLeSequelle.Models.Personal");

                    b.Property<int>("TilläggsbeställningsId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Servitör");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Bokning", b =>
                {
                    b.HasOne("HotelLeSequelle.Models.Personal", "BokandePersonal")
                        .WithMany()
                        .HasForeignKey("BokandePersonalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLeSequelle.Models.Rum", "BokatRum")
                        .WithMany("RummetsBokningar")
                        .HasForeignKey("BokatRumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLeSequelle.Models.Hotell", "BokningensHotell")
                        .WithMany("Bokningar")
                        .HasForeignKey("HotellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLeSequelle.Models.Kund", "BokandeKund")
                        .WithMany("Boknings")
                        .HasForeignKey("KundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLeSequelle.Models.Receptionist", null)
                        .WithMany("Bokningar")
                        .HasForeignKey("ReceptionistId");

                    b.Navigation("BokandeKund");

                    b.Navigation("BokandePersonal");

                    b.Navigation("BokatRum");

                    b.Navigation("BokningensHotell");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Rum", b =>
                {
                    b.HasOne("HotelLeSequelle.Models.Våning", "RummetsVåning")
                        .WithMany("Rum")
                        .HasForeignKey("RummetsVåningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RummetsVåning");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Tilläggsbeställning", b =>
                {
                    b.HasOne("HotelLeSequelle.Models.Bokning", "Bokning")
                        .WithMany("Tilläggsbeställningar")
                        .HasForeignKey("BokningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLeSequelle.Models.Personal", "Personal")
                        .WithMany("Tilläggsbestälningar")
                        .HasForeignKey("PersonalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLeSequelle.Models.Receptionist", null)
                        .WithMany("Tilläggsbeställningar")
                        .HasForeignKey("ReceptionistId");

                    b.HasOne("HotelLeSequelle.Models.Servitör", null)
                        .WithMany("Tilläggsbeställnings")
                        .HasForeignKey("ServitörId");

                    b.Navigation("Bokning");

                    b.Navigation("Personal");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Våning", b =>
                {
                    b.HasOne("HotelLeSequelle.Models.Hotell", "Hotell")
                        .WithMany("Våningar")
                        .HasForeignKey("HotellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotell");
                });

            modelBuilder.Entity("TilläggsbeställningTilläggsvara", b =>
                {
                    b.HasOne("HotelLeSequelle.Models.Tilläggsbeställning", null)
                        .WithMany()
                        .HasForeignKey("TilläggsbeställningarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLeSequelle.Models.Tilläggsvara", null)
                        .WithMany()
                        .HasForeignKey("TilläggsvarorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Bokning", b =>
                {
                    b.Navigation("Tilläggsbeställningar");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Hotell", b =>
                {
                    b.Navigation("Bokningar");

                    b.Navigation("Våningar");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Kund", b =>
                {
                    b.Navigation("Boknings");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Personal", b =>
                {
                    b.Navigation("Tilläggsbestälningar");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Rum", b =>
                {
                    b.Navigation("RummetsBokningar");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Våning", b =>
                {
                    b.Navigation("Rum");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Receptionist", b =>
                {
                    b.Navigation("Bokningar");

                    b.Navigation("Tilläggsbeställningar");
                });

            modelBuilder.Entity("HotelLeSequelle.Models.Servitör", b =>
                {
                    b.Navigation("Tilläggsbeställnings");
                });
#pragma warning restore 612, 618
        }
    }
}
