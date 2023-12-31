﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20231104192011_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Data.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdEntertainment")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdEntertainment");

                    b.ToTable("Characters", (string)null);
                });

            modelBuilder.Entity("Data.Models.Entertainment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Release")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Entertainment");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Entertainment");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Data.Models.Content.Anime", b =>
                {
                    b.HasBaseType("Data.Models.Entertainment");

                    b.Property<int>("Episodes")
                        .HasColumnType("int");

                    b.Property<int>("Seasons")
                        .HasColumnType("int");

                    b.Property<string>("Studio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Entertainment", t =>
                        {
                            t.Property("Episodes")
                                .HasColumnName("Anime_Episodes");

                            t.Property("Seasons")
                                .HasColumnName("Anime_Seasons");
                        });

                    b.HasDiscriminator().HasValue("Anime");
                });

            modelBuilder.Entity("Data.Models.Content.Book", b =>
                {
                    b.HasBaseType("Data.Models.Entertainment");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.ToTable("Entertainment", t =>
                        {
                            t.Property("Author")
                                .HasColumnName("Book_Author");

                            t.Property("Pages")
                                .HasColumnName("Book_Pages");
                        });

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("Data.Models.Content.Comic", b =>
                {
                    b.HasBaseType("Data.Models.Entertainment");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.ToTable("Entertainment", t =>
                        {
                            t.Property("Author")
                                .HasColumnName("Comic_Author");

                            t.Property("Pages")
                                .HasColumnName("Comic_Pages");
                        });

                    b.HasDiscriminator().HasValue("Comic");
                });

            modelBuilder.Entity("Data.Models.Content.Manga", b =>
                {
                    b.HasBaseType("Data.Models.Entertainment");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.ToTable("Entertainment", t =>
                        {
                            t.Property("Author")
                                .HasColumnName("Manga_Author");

                            t.Property("Pages")
                                .HasColumnName("Manga_Pages");
                        });

                    b.HasDiscriminator().HasValue("Manga");
                });

            modelBuilder.Entity("Data.Models.Content.Movie", b =>
                {
                    b.HasBaseType("Data.Models.Entertainment");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Entertainment", t =>
                        {
                            t.Property("Director")
                                .HasColumnName("Movie_Director");
                        });

                    b.HasDiscriminator().HasValue("Movie");
                });

            modelBuilder.Entity("Data.Models.Content.Novel", b =>
                {
                    b.HasBaseType("Data.Models.Entertainment");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Novel");
                });

            modelBuilder.Entity("Data.Models.Content.Serie", b =>
                {
                    b.HasBaseType("Data.Models.Entertainment");

                    b.Property<int>("Director")
                        .HasColumnType("int");

                    b.Property<string>("Episodes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Seasons")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Serie");
                });

            modelBuilder.Entity("Data.Models.Character", b =>
                {
                    b.HasOne("Data.Models.Entertainment", "Entertainment")
                        .WithMany("Characters")
                        .HasForeignKey("IdEntertainment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entertainment");
                });

            modelBuilder.Entity("Data.Models.Entertainment", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
