
namespace FilmWebApi.Entities
{
    public class Actor
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public ICollection<Movie> Movies { get; set; } = [];
    }
}
