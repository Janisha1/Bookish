﻿// <auto-generated />
using System;
using Bookish;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bookish.Migrations
{
    [DbContext(typeof(BookishDbContext))]
    partial class BookishDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthorModelBookModel", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("integer");

                    b.Property<string>("BooksIsbn")
                        .HasColumnType("text");

                    b.HasKey("AuthorsId", "BooksIsbn");

                    b.HasIndex("BooksIsbn");

                    b.ToTable("AuthorModelBookModel");
                });

            modelBuilder.Entity("Bookish.Models.Database.AuthorModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("AuthorPhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("YearOfBirth")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Bookish.Models.Database.BookCopyModel", b =>
                {
                    b.Property<string>("Barcode")
                        .HasColumnType("text");

                    b.Property<string>("BookIsbn")
                        .HasColumnType("text");

                    b.HasKey("Barcode");

                    b.HasIndex("BookIsbn");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("Bookish.Models.Database.BookModel", b =>
                {
                    b.Property<string>("Isbn")
                        .HasColumnType("text");

                    b.Property<string>("Blurb")
                        .HasColumnType("text");

                    b.Property<string>("CoverPhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int?>("YearPublished")
                        .HasColumnType("integer");

                    b.HasKey("Isbn");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("AuthorModelBookModel", b =>
                {
                    b.HasOne("Bookish.Models.Database.AuthorModel", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookish.Models.Database.BookModel", null)
                        .WithMany()
                        .HasForeignKey("BooksIsbn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookish.Models.Database.BookCopyModel", b =>
                {
                    b.HasOne("Bookish.Models.Database.BookModel", "Book")
                        .WithMany("Copies")
                        .HasForeignKey("BookIsbn");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Bookish.Models.Database.BookModel", b =>
                {
                    b.Navigation("Copies");
                });
#pragma warning restore 612, 618
        }
    }
}