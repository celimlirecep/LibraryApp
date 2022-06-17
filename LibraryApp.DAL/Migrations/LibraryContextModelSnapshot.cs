﻿// <auto-generated />
using System;
using LibraryApp.DAL.Concreate.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryApp.DAL.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("LİbraryApp.EL.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("BookStock")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentStock")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            BookImage = "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg",
                            BookName = "Dinle Küçük Adam",
                            BookStock = 5,
                            CurrentStock = 5
                        },
                        new
                        {
                            BookId = 2,
                            BookImage = "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg",
                            BookName = "Nar Ağacı",
                            BookStock = 5,
                            CurrentStock = 8
                        },
                        new
                        {
                            BookId = 3,
                            BookImage = "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg",
                            BookName = "Savaşçı",
                            BookStock = 5,
                            CurrentStock = 5
                        },
                        new
                        {
                            BookId = 4,
                            BookImage = "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg",
                            BookName = "Doğmamış Çocuğa Mektup",
                            BookStock = 5,
                            CurrentStock = 3
                        },
                        new
                        {
                            BookId = 5,
                            BookImage = "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg",
                            BookName = "Küçük Kara Balık",
                            BookStock = 5,
                            CurrentStock = 10
                        },
                        new
                        {
                            BookId = 6,
                            BookImage = "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg",
                            BookName = "Uygarlıkların Batışı",
                            BookStock = 5,
                            CurrentStock = 7
                        });
                });

            modelBuilder.Entity("LİbraryApp.EL.BookReserve", b =>
                {
                    b.Property<int>("BookReserveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BarrowingDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserCardId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookReserveId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserCardId");

                    b.ToTable("BookReserves");
                });

            modelBuilder.Entity("LİbraryApp.EL.UserCard", b =>
                {
                    b.Property<int>("UserCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserCardId");

                    b.ToTable("UserCards");
                });

            modelBuilder.Entity("LİbraryApp.EL.BookReserve", b =>
                {
                    b.HasOne("LİbraryApp.EL.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LİbraryApp.EL.UserCard", "UserCard")
                        .WithMany("BookReserves")
                        .HasForeignKey("UserCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("UserCard");
                });

            modelBuilder.Entity("LİbraryApp.EL.UserCard", b =>
                {
                    b.Navigation("BookReserves");
                });
#pragma warning restore 612, 618
        }
    }
}
