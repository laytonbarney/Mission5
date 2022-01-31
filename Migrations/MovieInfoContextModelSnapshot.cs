﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieCollection.Models;

namespace MovieCollection.Migrations
{
    [DbContext(typeof(MovieInfoContext))]
    partial class MovieInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("MovieCollection.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Action"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Drama"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Fantasy"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Horror"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Mystery"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "Romance"
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryName = "Thriller"
                        },
                        new
                        {
                            CategoryId = 9,
                            CategoryName = "Western"
                        });
                });

            modelBuilder.Entity("MovieCollection.Models.MovieDB", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DirectorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CategoryId = 3,
                            DirectorName = "Steven Spielberg",
                            Edited = false,
                            Rating = "R",
                            Title = "Schindler's List",
                            Year = 1993
                        },
                        new
                        {
                            MovieId = 2,
                            CategoryId = 3,
                            DirectorName = "Christopher Nolan",
                            Edited = false,
                            Rating = "PG-13",
                            Title = "Inception",
                            Year = 2010
                        },
                        new
                        {
                            MovieId = 3,
                            CategoryId = 3,
                            DirectorName = "Frank Capra",
                            Edited = false,
                            Rating = "PG",
                            Title = "It's a Wonderful Life",
                            Year = 1946
                        });
                });

            modelBuilder.Entity("MovieCollection.Models.MovieDB", b =>
                {
                    b.HasOne("MovieCollection.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}