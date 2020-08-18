﻿// <auto-generated />
using System;
using ComITBakery.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ComITBakery.Migrations
{
    [DbContext(typeof(BakeryContext))]
    partial class BakeryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ComITBakery.Models.Batch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("InitialQuantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("InventoryItemId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("RemainingQuantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InventoryItemId");

                    b.ToTable("Batch");
                });

            modelBuilder.Entity("ComITBakery.Models.InventoryItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DaysToSell")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ComITBakery.Models.Batch", b =>
                {
                    b.HasOne("ComITBakery.Models.InventoryItem", null)
                        .WithMany("Batches")
                        .HasForeignKey("InventoryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}