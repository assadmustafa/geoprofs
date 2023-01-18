﻿// <auto-generated />
using System;
using GeoProfs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeoProfs.Migrations
{
    [DbContext(typeof(BedrijfContext))]
    partial class BedrijfContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeoProfs.Models.Afdeling", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Afdeling");
                });

            modelBuilder.Entity("GeoProfs.Models.Functie", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int?>("AfdelingID")
                        .HasColumnType("int");

                    b.Property<int>("afdeling_ID")
                        .HasColumnType("int");

                    b.Property<string>("naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AfdelingID");

                    b.ToTable("Functie");
                });

            modelBuilder.Entity("GeoProfs.Models.Rapport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FunctieID")
                        .HasColumnType("int");

                    b.Property<int?>("VerlofaanvraagID")
                        .HasColumnType("int");

                    b.Property<int?>("WerknemerID")
                        .HasColumnType("int");

                    b.Property<double>("aanwezige_dagen")
                        .HasColumnType("float");

                    b.Property<double>("afwezige_dagen")
                        .HasColumnType("float");

                    b.Property<int>("functie_ID")
                        .HasColumnType("int");

                    b.Property<int>("verlofaanvraag_ID")
                        .HasColumnType("int");

                    b.Property<int>("weeknummer")
                        .HasColumnType("int");

                    b.Property<int>("werknemer_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FunctieID");

                    b.HasIndex("VerlofaanvraagID");

                    b.HasIndex("WerknemerID");

                    b.ToTable("Rapport");
                });

            modelBuilder.Entity("GeoProfs.Models.Verlofaanvraag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("WerkenemerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("begin_datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("beschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("eind_datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.Property<int?>("verlof_reden")
                        .HasColumnType("int");

                    b.Property<int>("werknemer_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("WerkenemerID");

                    b.ToTable("Verlofaanvraag");
                });

            modelBuilder.Entity("GeoProfs.Models.Werknemer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BSN")
                        .HasColumnType("int");

                    b.Property<string>("achternaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("contract_uren")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("functie_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("geboortedatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("telefoonnummer")
                        .HasColumnType("int");

                    b.Property<double>("uurloon")
                        .HasColumnType("float");

                    b.Property<string>("voornaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("wachtwoord")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Werknemer");
                });

            modelBuilder.Entity("GeoProfs.Models.Functie", b =>
                {
                    b.HasOne("GeoProfs.Models.Afdeling", "Afdeling")
                        .WithMany()
                        .HasForeignKey("AfdelingID");

                    b.Navigation("Afdeling");
                });

            modelBuilder.Entity("GeoProfs.Models.Rapport", b =>
                {
                    b.HasOne("GeoProfs.Models.Functie", "Functie")
                        .WithMany()
                        .HasForeignKey("FunctieID");

                    b.HasOne("GeoProfs.Models.Verlofaanvraag", "Verlofaanvraag")
                        .WithMany()
                        .HasForeignKey("VerlofaanvraagID");

                    b.HasOne("GeoProfs.Models.Werknemer", "Werknemer")
                        .WithMany()
                        .HasForeignKey("WerknemerID");

                    b.Navigation("Functie");

                    b.Navigation("Verlofaanvraag");

                    b.Navigation("Werknemer");
                });

            modelBuilder.Entity("GeoProfs.Models.Verlofaanvraag", b =>
                {
                    b.HasOne("GeoProfs.Models.Werknemer", "Werkenemer")
                        .WithMany("Verlofs")
                        .HasForeignKey("WerkenemerID");

                    b.Navigation("Werkenemer");
                });

            modelBuilder.Entity("GeoProfs.Models.Werknemer", b =>
                {
                    b.Navigation("Verlofs");
                });
#pragma warning restore 612, 618
        }
    }
}
