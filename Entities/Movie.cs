namespace FilmWebApi.Entities;

public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public int Duration { get; set; }
    public DateTime Released { get; set;}
    public int Year { get; set; }
    public Director Director { get; set; } = null!;
    public Production Production { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Language { get; set; } = null!;
    public ICollection<Actor> Actors { get; set; } = [];
    public ICollection<Category> Categories { get; set; } = [];
}
