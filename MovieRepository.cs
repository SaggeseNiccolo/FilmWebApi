namespace FilmWebApi
{
        public class MovieRepository : IMovieRepository
        {
            private readonly string _connectionString;

            public MovieRepository(IConfiguration configuration)
            {
                this._connectionString = configuration.GetConnectionString("Film") ?? string.Empty;
            }
        }
}
