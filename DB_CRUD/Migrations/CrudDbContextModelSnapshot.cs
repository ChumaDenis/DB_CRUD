﻿// <auto-generated />
using System;
using DB_CRUD.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DB_CRUD.Migrations
{
    [DbContext(typeof(CrudDbContext))]
    partial class CrudDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DB_CRUD.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<string>("ItemsDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OrderCost")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            ItemsDescription = "red",
                            OrderCost = 1m,
                            OrderDate = new DateTime(2023, 5, 11, 21, 52, 18, 650, DateTimeKind.Local).AddTicks(8492),
                            ShippingAddress = "Lviv",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("DB_CRUD.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            DateOfBirth = new DateTime(2002, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Test1",
                            Gender = "M",
                            LastName = "test1",
                            Login = "redredred",
                            Password = "redredred"
                        },
                        new
                        {
                            UserID = 2,
                            DateOfBirth = new DateTime(2000, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Test2",
                            Gender = "F",
                            LastName = "test2",
                            Login = "blueblueblue",
                            Password = "blueblueblue"
                        },
                        new
                        {
                            UserID = 3,
                            DateOfBirth = new DateTime(1998, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Test3",
                            Gender = "F",
                            LastName = "test3",
                            Login = "blueblue",
                            Password = "blueblue"
                        });
                });

            modelBuilder.Entity("DB_CRUD.Models.Order", b =>
                {
                    b.HasOne("DB_CRUD.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
