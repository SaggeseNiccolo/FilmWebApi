using FilmWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmWebApi;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Production> Productions { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Category> Categories { get; set; }

    private static readonly string dataSource = "localhost";
    private static readonly string initialCatalog = "FilmWebApiDB";
    private readonly string connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};Integrated Security=true;TrustServerCertificate=true;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Director)
            .WithMany(d => d.Movies)
            .HasForeignKey(m => m.DirectorId);
            
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Production)
            .WithMany(p => p.Movies)
            .HasForeignKey(m => m.ProductionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Actors)
            .WithMany(a => a.Movies);

        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Categories)
            .WithMany(c => c.Movies);
    }
}
