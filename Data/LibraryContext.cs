using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Data.Models.Content;
using Data.Models;


namespace Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Entertainment> Entertainment { get; set; }
        public DbSet<Manga> Manga { get; set; }
        public DbSet<Anime> Anime { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<Novel> Novel { get; set; }
        public DbSet<Comic> Comic { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Character> Character { get; set; }

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
            modelBuilder.Entity<Entertainment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(name => name.Name).IsRequired();
                entity.HasMany(c => c.Characters)
                .WithOne(c => c.Entertainment)
                .HasForeignKey(f => f.IdEntertainment)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Character>(entity => {
                entity.ToTable("Characters");
                entity.Property(entity => entity.Name).IsRequired();
            }); 
        }
    }
}
