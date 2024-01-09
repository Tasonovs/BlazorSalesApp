﻿// <auto-generated />
using System;
using BlazorSalesApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorSalesApp.Infrastructure.Migrations
{
    [DbContext(typeof(BlazorSalesAppContext))]
    partial class BlazorSalesAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorSalesApp.Domain.Models.Orders.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<long>("StateId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Orders", "dbo");
                });

            modelBuilder.Entity("BlazorSalesApp.Domain.Models.Orders.OrderStateLookup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrderStateLookup", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Label = "NY"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Label = "CA"
                        });
                });

            modelBuilder.Entity("BlazorSalesApp.Domain.Models.SubElements.SubElement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.Property<long?>("WindowId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("WindowId");

                    b.ToTable("SubElements", "dbo");
                });

            modelBuilder.Entity("BlazorSalesApp.Domain.Models.SubElements.SubElementTypeLookup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SubElementTypeLookup", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Label = "Window"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Label = "Doors"
                        });
                });

            modelBuilder.Entity("BlazorSalesApp.Domain.Models.Windows.Window", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("QuantityOfWindows")
                        .HasColumnType("int");

                    b.Property<int>("TotalSubElements")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Windows", "dbo");
                });

            modelBuilder.Entity("BlazorSalesApp.Domain.Models.Orders.Order", b =>
                {
                    b.HasOne("BlazorSalesApp.Domain.Models.Orders.OrderStateLookup", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("BlazorSalesApp.Domain.Models.SubElements.SubElement", b =>
                {
                    b.HasOne("BlazorSalesApp.Domain.Models.SubElements.SubElementTypeLookup", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorSalesApp.Domain.Models.Windows.Window", null)
                        .WithMany("SubElements")
                        .HasForeignKey("WindowId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("BlazorSalesApp.Domain.Models.Windows.Window", b =>
                {
                    b.HasOne("BlazorSalesApp.Domain.Models.Orders.Order", null)
                        .WithMany("Windows")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("BlazorSalesApp.Domain.Models.Orders.Order", b =>
                {
                    b.Navigation("Windows");
                });

            modelBuilder.Entity("BlazorSalesApp.Domain.Models.Windows.Window", b =>
                {
                    b.Navigation("SubElements");
                });
#pragma warning restore 612, 618
        }
    }
}
