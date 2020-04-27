﻿// <auto-generated />
using System;
using CodeFirst.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirst.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200427132713_AddedStationProductRelation")]
    partial class AddedStationProductRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("CodeFirst.Models.AssemblyStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Mandatory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AssemblyStep");
                });

            modelBuilder.Entity("CodeFirst.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PartDefintionId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PartDefintionId");

                    b.HasIndex("ProductId");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("CodeFirst.Models.PartDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PartDefinition");
                });

            modelBuilder.Entity("CodeFirst.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("End")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RoundId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<int>("StationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.HasIndex("StationId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CodeFirst.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("End")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("CodeFirst.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RoundId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Station");
                });

            modelBuilder.Entity("CodeFirst.Models.StationAssemblyStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AssemblyStepId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AssemblyStepId");

                    b.HasIndex("StationId");

                    b.ToTable("StationAssemblyStep");
                });

            modelBuilder.Entity("CodeFirst.Models.Part", b =>
                {
                    b.HasOne("CodeFirst.Models.PartDefinition", "PartDefintion")
                        .WithMany("Parts")
                        .HasForeignKey("PartDefintionId");

                    b.HasOne("CodeFirst.Models.Product", "Product")
                        .WithMany("Parts")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("CodeFirst.Models.Product", b =>
                {
                    b.HasOne("CodeFirst.Models.Round", "Round")
                        .WithMany("Products")
                        .HasForeignKey("RoundId");

                    b.HasOne("CodeFirst.Models.Station", "Station")
                        .WithMany("Products")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeFirst.Models.Station", b =>
                {
                    b.HasOne("CodeFirst.Models.Round", "Round")
                        .WithMany("Stations")
                        .HasForeignKey("RoundId");
                });

            modelBuilder.Entity("CodeFirst.Models.StationAssemblyStep", b =>
                {
                    b.HasOne("CodeFirst.Models.AssemblyStep", "AssemblyStep")
                        .WithMany("StationAssemblySteps")
                        .HasForeignKey("AssemblyStepId");

                    b.HasOne("CodeFirst.Models.Station", "Station")
                        .WithMany("StationAssemblySteps")
                        .HasForeignKey("StationId");
                });
#pragma warning restore 612, 618
        }
    }
}
