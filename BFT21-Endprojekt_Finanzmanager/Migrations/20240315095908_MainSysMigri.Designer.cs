﻿// <auto-generated />
using System;
using BFT21_Endprojekt_Finanzmanager.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BFT21_Endprojekt_Finanzmanager.Migrations
{
    [DbContext(typeof(DatabaseDefiner))]
    [Migration("20240315095908_MainSysMigri")]
    partial class MainSysMigri
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.28");

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.BLZ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Nummer")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("BankLeitZahl");
                });

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.Buchung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("BruttoSum")
                        .HasColumnType("REAL");

                    b.Property<short>("BuchungsTyp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EigKontoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExtKontoId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("NettoSum")
                        .HasColumnType("REAL");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EigKontoId");

                    b.HasIndex("ExtKontoId");

                    b.HasIndex("UserId");

                    b.ToTable("Buchungen");
                });

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.BuchungsPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amt")
                        .HasColumnType("INTEGER");

                    b.Property<double>("BPPU")
                        .HasColumnType("REAL");

                    b.Property<double>("BruttoPreis")
                        .HasColumnType("REAL");

                    b.Property<int>("BuchungId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("NettoPreis")
                        .HasColumnType("REAL");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionsTypId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BuchungId");

                    b.HasIndex("PositionsTypId");

                    b.ToTable("BuchungsPositionen");
                });

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.Konto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BankLeitZahlId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Betrag")
                        .HasColumnType("REAL");

                    b.Property<DateOnly>("Gültigkeit")
                        .HasColumnType("TEXT");

                    b.Property<int>("KontoNummer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("KontoTyp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kontrollsumme")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LaendercodeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TF1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BankLeitZahlId");

                    b.HasIndex("LaendercodeId");

                    b.HasIndex("UserId");

                    b.ToTable("Konten");
                });

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.Laendercode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kürzel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Laendercodes");
                });

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.PositionsTyp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Absetzbar")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Steuersatz")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PositionsTypen");
                });

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.Buchung", b =>
                {
                    b.HasOne("BFT21_Endprojekt_Finanzmanager.Database.Datasets.Konto", "EigKonto")
                        .WithMany()
                        .HasForeignKey("EigKontoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BFT21_Endprojekt_Finanzmanager.Database.Datasets.Konto", "ExtKonto")
                        .WithMany()
                        .HasForeignKey("ExtKontoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BFT21_Endprojekt_Finanzmanager.Database.Datasets.User", null)
                        .WithMany("Buchungen")
                        .HasForeignKey("UserId");

                    b.Navigation("EigKonto");

                    b.Navigation("ExtKonto");
                });

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.BuchungsPosition", b =>
                {
                    b.HasOne("BFT21_Endprojekt_Finanzmanager.Database.Datasets.Buchung", "Buchung")
                        .WithMany("Positionen")
                        .HasForeignKey("BuchungId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BFT21_Endprojekt_Finanzmanager.Database.Datasets.PositionsTyp", "PositionsTyp")
                        .WithMany()
                        .HasForeignKey("PositionsTypId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buchung");

                    b.Navigation("PositionsTyp");
                });

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.Konto", b =>
                {
                    b.HasOne("BFT21_Endprojekt_Finanzmanager.Database.Datasets.BLZ", "BankLeitZahl")
                        .WithMany()
                        .HasForeignKey("BankLeitZahlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BFT21_Endprojekt_Finanzmanager.Database.Datasets.Laendercode", "Laendercode")
                        .WithMany()
                        .HasForeignKey("LaendercodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BFT21_Endprojekt_Finanzmanager.Database.Datasets.User", "User")
                        .WithMany("Konten")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankLeitZahl");

                    b.Navigation("Laendercode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.Buchung", b =>
                {
                    b.Navigation("Positionen");
                });

            modelBuilder.Entity("BFT21_Endprojekt_Finanzmanager.Database.Datasets.User", b =>
                {
                    b.Navigation("Buchungen");

                    b.Navigation("Konten");
                });
#pragma warning restore 612, 618
        }
    }
}
