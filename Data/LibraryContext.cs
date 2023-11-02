using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Anime> Anime { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Comic> Comic { get; set; }
        public DbSet<Manga> Manga { get; set; }
        public DbSet<Novel> Novel { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<Movie> Movie { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                var connectionString = builder.Build().GetConnectionString("defaultConnection");
                options.UseMySQL(connectionString);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error getting connection: {e}");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>(entity =>
            {
                entity.ToTable("Anime");
                entity.HasKey(id => id.Id);
                entity.Property(name => name.Name).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");
                entity.HasKey(id => id.Id);
                entity.Property(name => name.Name).IsRequired();
            });

            modelBuilder.Entity<Comic>(entity =>
            {
                entity.ToTable("Comic");
                entity.HasKey(id => id.Id);
                entity.Property(name => name.Name).IsRequired();
            });

            modelBuilder.Entity<Manga>(entity =>
            {
                entity.ToTable("Manga");
                entity.HasKey(id => id.Id);
                entity.Property(name => name.Name).IsRequired();
            });

            modelBuilder.Entity<Novel>(entity =>
            {
                entity.ToTable("Novel");
                entity.HasKey(id => id.Id);
                entity.Property(name => name.Name).IsRequired();
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.ToTable("Serie");
                entity.HasKey(id => id.Id);
                entity.Property(name => name.Name).IsRequired();
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");
                entity.HasKey(id => id.Id);
                entity.Property(name => name.Name).IsRequired();
            });
        }
    }
}
