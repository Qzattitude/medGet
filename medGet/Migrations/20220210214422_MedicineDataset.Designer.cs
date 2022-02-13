﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using medGet.Database;

#nullable disable

namespace medGet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220210214422_MedicineDataset")]
    partial class MedicineDataset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("medGet.Models.MedicineDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DAR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dosages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Generic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strength")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsedFor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MedicineDetails");
                });
#pragma warning restore 612, 618
        }
    }
}