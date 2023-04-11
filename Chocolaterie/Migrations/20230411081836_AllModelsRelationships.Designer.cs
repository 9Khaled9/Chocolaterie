﻿// <auto-generated />
using Chocolaterie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chocolaterie.Migrations
{
    [DbContext(typeof(ChocolaterieContext))]
    [Migration("20230411081836_AllModelsRelationships")]
    partial class AllModelsRelationships
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Chocolaterie.Models.ChocolateBar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FactoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.ToTable("ChocolateBar");
                });

            modelBuilder.Entity("Chocolaterie.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Chocolaterie.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("Chocolaterie.Models.Factory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Factory");
                });

            modelBuilder.Entity("Chocolaterie.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountAmount")
                        .HasColumnType("int");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<int>("OrderType")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("TotalAfterDiscount")
                        .HasColumnType("int");

                    b.Property<int>("WholeSalerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("WholeSalerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Chocolaterie.Models.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("StockId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("Chocolaterie.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChocolateBarId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quatity")
                        .HasColumnType("int");

                    b.Property<int>("WholeSalerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChocolateBarId");

                    b.HasIndex("WholeSalerId");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Chocolaterie.Models.WholeSaler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WholeSaler");
                });

            modelBuilder.Entity("Chocolaterie.Models.ChocolateBar", b =>
                {
                    b.HasOne("Chocolaterie.Models.Factory", "Factory")
                        .WithMany("ChocolateBars")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factory");
                });

            modelBuilder.Entity("Chocolaterie.Models.Order", b =>
                {
                    b.HasOne("Chocolaterie.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chocolaterie.Models.Discount", "Discount")
                        .WithMany("Orders")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chocolaterie.Models.WholeSaler", "WholeSaler")
                        .WithMany("Orders")
                        .HasForeignKey("WholeSalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Discount");

                    b.Navigation("WholeSaler");
                });

            modelBuilder.Entity("Chocolaterie.Models.OrderLine", b =>
                {
                    b.HasOne("Chocolaterie.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chocolaterie.Models.Stock", "Stock")
                        .WithMany("OrderLines")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("Chocolaterie.Models.Stock", b =>
                {
                    b.HasOne("Chocolaterie.Models.ChocolateBar", "ChocolateBar")
                        .WithMany("Stocks")
                        .HasForeignKey("ChocolateBarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chocolaterie.Models.WholeSaler", "WholeSaler")
                        .WithMany("Stocks")
                        .HasForeignKey("WholeSalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChocolateBar");

                    b.Navigation("WholeSaler");
                });

            modelBuilder.Entity("Chocolaterie.Models.ChocolateBar", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("Chocolaterie.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Chocolaterie.Models.Discount", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Chocolaterie.Models.Factory", b =>
                {
                    b.Navigation("ChocolateBars");
                });

            modelBuilder.Entity("Chocolaterie.Models.Order", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("Chocolaterie.Models.Stock", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("Chocolaterie.Models.WholeSaler", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}