﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using hackyeah.App.Infrastructure.DataAccess;

#nullable disable

namespace hackyeah.App.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("hackyeah.App.Domain.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Voivodeship")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("X")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Y")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("_cities");
                });

            modelBuilder.Entity("hackyeah.App.Domain.Entities.Direction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.Property<int>("RateCount")
                        .HasColumnType("integer");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("_directions");
                });

            modelBuilder.Entity("hackyeah.App.Domain.Entities.UniversityData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreationDateOrEntryDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InstitutionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KRS")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("REGON")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.Property<int>("RateCount")
                        .HasColumnType("integer");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("_universityData");
                });

            modelBuilder.Entity("hackyeah.App.Domain.Entities.Direction", b =>
                {
                    b.HasOne("hackyeah.App.Domain.Entities.UniversityData", "University")
                        .WithMany("Directions")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("hackyeah.App.Domain.Entities.UniversityData", b =>
                {
                    b.OwnsOne("hackyeah.App.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UniversityDataId")
                                .HasColumnType("uuid");

                            b1.Property<string>("BuildingNumber")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("PostCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UniversityDataId");

                            b1.ToTable("_universityData");

                            b1.WithOwner()
                                .HasForeignKey("UniversityDataId");
                        });

                    b.OwnsOne("hackyeah.App.Domain.ValueObjects.MapLocalization", "MapLocalization", b1 =>
                        {
                            b1.Property<Guid>("UniversityDataId")
                                .HasColumnType("uuid");

                            b1.Property<string>("X")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Y")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UniversityDataId");

                            b1.ToTable("_universityData");

                            b1.WithOwner()
                                .HasForeignKey("UniversityDataId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("MapLocalization")
                        .IsRequired();
                });

            modelBuilder.Entity("hackyeah.App.Domain.Entities.UniversityData", b =>
                {
                    b.Navigation("Directions");
                });
#pragma warning restore 612, 618
        }
    }
}
