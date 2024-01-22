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
}
