using System.Globalization;

namespace FilmWebApi.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime Released { get; set;}
        public int Year { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public Director DirectorId { get; set; }
        public Production ProductionId { get; set; }
    }
}
