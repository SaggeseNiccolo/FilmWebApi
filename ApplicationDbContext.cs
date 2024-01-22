using FilmWebApi.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FilmWebApi
{
    public class ApplicationDbContext : DbContext
    {
        string _stringConnection = "Data Source=localhost;Initial Catalog=Film;Integrated Security=true;TrustServerCertificate=true;";
        ModelBuilder _modelBuilder;

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Production> Productions { get; set; }
        public virtual DbSet<CategoryMovie> CategoryMovies { get; set; }
        public virtual DbSet<ActorMovie> ActorMovies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            var connection = new SqlConnection(_stringConnection);
            connection.Open();

            _modelBuilder = new ModelBuilder();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._stringConnection);
        }
    }
}
