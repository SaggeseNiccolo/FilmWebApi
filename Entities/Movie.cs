namespace FilmWebApi.Entities;

public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public int Duration { get; set; }
    public DateTime Released { get; set;}
    public int Year { get; set; }
    public required Director Director { get; set; }
    public required Production Production { get; set; }
    public string Country { get; set; } = null!;
    public string Language { get; set; } = null!;
    public Guid DirectorId { get; set; }
    public Guid ProductionId { get; set; }
    public ICollection<Actor> Actors { get; set; } = [];
    public ICollection<Category> Categories { get; set; } = [];
}
