﻿// <auto-generated />
using System;
using Data.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DividendDashDbContext))]
    [Migration("20241212175839_Add Fluent API for Delete Cascade")]
    partial class AddFluentAPIforDeleteCascade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Domain.Holding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Holdings");
                });

            modelBuilder.Entity("Data.Domain.Summary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Dividend")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("DividendCharges")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateOnly>("DividendDate")
                        .HasColumnType("date");

                    b.Property<decimal>("DividendTotal")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateOnly>("ExDate")
                        .HasColumnType("date");

                    b.Property<decimal>("Gross")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("HoldingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<decimal>("Net")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Profit")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TotalCharges")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("HoldingId")
                        .IsUnique();

                    b.ToTable("Summaries");
                });

            modelBuilder.Entity("Data.Domain.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Closing")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("ClosingCharges")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("ClosingTotal")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("HoldingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<decimal>("Opening")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("OpeningCharges")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("OpeningTotal")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("HoldingId")
                        .IsUnique();

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Data.Domain.Summary", b =>
                {
                    b.HasOne("Data.Domain.Holding", "Holding")
                        .WithOne("Summary")
                        .HasForeignKey("Data.Domain.Summary", "HoldingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Holding");
                });

            modelBuilder.Entity("Data.Domain.Transaction", b =>
                {
                    b.HasOne("Data.Domain.Holding", "Holding")
                        .WithOne("Transaction")
                        .HasForeignKey("Data.Domain.Transaction", "HoldingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Holding");
                });

            modelBuilder.Entity("Data.Domain.Holding", b =>
                {
                    b.Navigation("Summary");

                    b.Navigation("Transaction");
                });
#pragma warning restore 612, 618
        }
    }
}