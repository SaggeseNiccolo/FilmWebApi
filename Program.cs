using FilmWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmWebApi;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "FilmWebApi", Version = "v1" });
        });

        builder.Services.AddDbContext<MovieContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FilmWebApi v1"));
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        using var db = new MovieContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        var actors = new List<Actor>
             {
                 new Actor
                 {
                     Name = "Brad",
                     LastName = "Pitt",
                     BirthDate = new DateTime(1963, 12, 18)
                 },
                 new Actor
                 {
                     Name = "Edward",
                     LastName = "Norton",
                     BirthDate = new DateTime(1969, 8, 18)
                 },
                 new Actor
                 {
                     Name = "Helena",
                     LastName = "Bonham Carter",
                     BirthDate = new DateTime(1966, 5, 26)
                 },
                 new Actor
                 {
                     Name = "Jared",
                     LastName = "Leto",
                     BirthDate = new DateTime(1971, 12, 26)
                 },
                 new Actor
                 {
                     Name = "Cate",
                     LastName = "Blanchett",
                     BirthDate = new DateTime(1969, 5, 14)
                 },
                 new Actor
                 {
                     Name = "Tilda",
                     LastName = "Swinton",
                     BirthDate = new DateTime(1960, 11, 5)
                 },
                 new Actor
                 {
                     Name = "Julia",
                     LastName = "Ormond",
                     BirthDate = new DateTime(1965, 1, 4)
                 },
                 new Actor
                 {
                     Name = "Faune",
                     LastName = "Chambers",
                     BirthDate = new DateTime(1976, 9, 23)
                 },
                 new Actor
                 {
                     Name = "Taraji",
                     LastName = "P. Henson",
                     BirthDate = new DateTime(1970, 9, 11)
                 },
                 new Actor
                 {
                     Name = "Morgan",
                     LastName = "Freeman",
                     BirthDate = new DateTime(1937, 6, 1)
                 },
                 new Actor
                 {
                     Name = "Gwyneth",
                     LastName = "Paltrow",
                     BirthDate = new DateTime(1972, 9, 27)
                 },
                 new Actor
                 {
                     Name = "Kevin",
                     LastName = "Spacey",
                     BirthDate = new DateTime(1959, 7, 26)
                 },
                 new Actor
                 {
                     Name = "John",
                     LastName = "C. McGinley",
                     BirthDate = new DateTime(1959, 8, 3)
                 },
                 new Actor
                 {
                     Name = "R. Lee",
                     LastName = "Ermey",
                     BirthDate = new DateTime(1944, 3, 24)
                 },
                 new Actor
                 {
                     Name = "Richard",
                     LastName = "Roundtree",
                     BirthDate = new DateTime(1942, 7, 9)
                 },
                 new Actor
                 {
                     Name = "Reg",
                     LastName = "E. Cathey",
                     BirthDate = new DateTime(1958, 8, 18)
                 },
                 new Actor
                 {
                     Name = "Daniel",
                     LastName = "Zovatto",
                     BirthDate = new DateTime(1991, 6, 28)
                 },
                 new Actor
                 {
                     Name = "Dylan",
                     LastName = "Minnette",
                     BirthDate = new DateTime(1996, 12, 29)
                 },
                 new Actor
                 {
                     Name = "Jane",
                     LastName = "Levy",
                     BirthDate = new DateTime(1989, 12, 29)
                 },
                 new Actor
                 {
                     Name = "Leonardo",
                     LastName = "Di Caprio",
                     BirthDate = new DateTime(1974, 11, 11)
                 },
                 new Actor
                 { 
                    Name = "Margot",
                    LastName = "Robbie",
                    BirthDate = new DateTime(1990, 07, 02)
                 },
                 new Actor
                 {
                    Name = "Tom",
                    LastName = "Holland",
                    BirthDate = new DateTime(1996, 06, 01)
                 },
                 new Actor
                 {
                    Name = "Zendaya",
                    LastName = "Coleman",
                    BirthDate = new DateTime(1996, 09, 01)
                 },
                 new Actor
                 {
                    Name = "Robert",
                    LastName = "Downey Jr",
                    BirthDate = new DateTime(1965, 04, 04)
                 },
                 new Actor
                 {
                    Name = "Steve",
                    LastName = "Carell",
                    BirthDate = new DateTime(1962, 08, 16)
                 },
                 new Actor
                 {
                    Name = "Samuel L.",
                    LastName = "Jackson",
                    BirthDate = new DateTime(1948, 12, 21)
                 },
                 new Actor
                 {
                    Name = "Scarlett",
                    LastName = "Johansson",
                    BirthDate = new DateTime(1984, 11, 22)
                 },
                 new Actor
                 {
                    Name = "Blake",
                    LastName = "Lively",
                    BirthDate = new DateTime(1987, 08, 25)
                 },
                 new Actor
                 {
                    Name = "Rayan",
                    LastName = "Reynolds",
                    BirthDate = new DateTime(1976, 11, 23)
                 },
                 new Actor
                 {
                    Name = "George",
                    LastName = "Clooney",
                    BirthDate = new DateTime(1961, 05, 06)
                 },
                 new Actor
                 {
                    Name = "Robert",
                    LastName = "De Niro",
                    BirthDate = new DateTime(1943, 08, 17)
                 },
                 new Actor
                 {
                    Name = "Johnny",
                    LastName = "Depp",
                    BirthDate = new DateTime(1963, 06, 09)
                 },
                 new Actor
                 {
                    Name = "Denzel",
                    LastName = "Washington",
                    BirthDate = new DateTime(1954, 12, 28)
                 },
                 new Actor
                 {
                    Name = "Tom",
                    LastName = "Cruise",
                    BirthDate = new DateTime(1962, 07, 03)
                 },
                 new Actor
                 {
                    Name = "Tom",
                    LastName = "Hanks",
                    BirthDate = new DateTime(1956, 07, 09)
                 },
                 new Actor
                 {
                    Name = "Robert",
                    LastName = "Pattinson",
                    BirthDate = new DateTime(1986, 05, 13)
                 },
                 new Actor
                 {
                    Name = "Bruce",
                    LastName = "Willis",
                    BirthDate = new DateTime(1955, 03, 19)
                 },
                 new Actor
                 {
                    Name = "Christian",
                    LastName = "Bale",
                    BirthDate = new DateTime(1974, 01, 30)
                 },
                 new Actor
                 {
                    Name = "Meryl",
                    LastName = "Streep",
                    BirthDate = new DateTime(1949, 06, 22)
                 },
                 new Actor
                 {
                    Name = "John",
                    LastName = "Travolta",
                    BirthDate = new DateTime(1954, 02, 18)
                 },
                 new Actor
                 {
                    Name = "Robert",
                    LastName = "Redford",
                    BirthDate = new DateTime(1936, 08, 18)
                 },
                 new Actor
                 {
                    Name = "Ben",
                    LastName = "Affleck",
                    BirthDate = new DateTime(1972, 08, 15)
                 },
                 new Actor
                 {
                    Name = "Angelina",
                    LastName = "Jolie",
                    BirthDate = new DateTime(1975, 06, 04)
                 },
                 new Actor
                 {
                    Name = "Michael",
                    LastName = "Caine",
                    BirthDate = new DateTime(1933, 03, 14)
                 },
                 new Actor
                 {
                    Name = "Matt",
                    LastName = "Damon",
                    BirthDate = new DateTime(1970, 10, 08)
                 },
                 new Actor
                 {
                    Name = "Nicolas",
                    LastName = "Cage",
                    BirthDate = new DateTime(1964, 01, 07)
                 },
                 new Actor
                 {
                    Name = "Stallone",
                    LastName = "Sylvester",
                    BirthDate = new DateTime(1946, 07, 06)
                 },
                 new Actor
                 {
                    Name = "Jack",
                    LastName = "Nicholson",
                    BirthDate = new DateTime(1937, 04, 22)
                 },
                 new Actor
                 {
                    Name = "Matthew",
                    LastName = "McConaughey",
                    BirthDate = new DateTime(1969, 11, 04)
                 },
                 new Actor
                 {
                    Name = "Jennifer",
                    LastName = "Aniston",
                    BirthDate = new DateTime(1969, 02, 11)
                 },
                 new Actor
                 {
                    Name = "Clint",
                    LastName = "Eastwood",
                    BirthDate = new DateTime(1930, 05, 31)
                 },
                 new Actor
                 {
                    Name = "Bradley",
                    LastName = "Cooper",
                    BirthDate = new DateTime(1975, 01, 05)
                 },
                 new Actor
                 {
                    Name = "Julia",
                    LastName = "Roberts",
                    BirthDate = new DateTime(1967, 10, 28)
                 },
                 new Actor
                 {
                    Name = "Sandra",
                    LastName = "Bullock",
                    BirthDate = new DateTime(1964, 07, 26)
                 },
                 new Actor
                 {
                    Name = "Dustin",
                    LastName = "Hoffman",
                    BirthDate = new DateTime(1937, 08, 08)
                 },
                 new Actor
                 {
                    Name = "Michelle",
                    LastName = "Pfeiffer",
                    BirthDate = new DateTime(1958, 04, 29)
                 },
                 new Actor
                 {
                    Name = "",
                    LastName = "",
                    BirthDate = new DateTime()
                 },
             };

        var directors = new List<Director>
             {
                 new Director
                 {
                     Name = "David",
                     LastName = "Fincher",
                     BirthDate = new DateTime(1962, 8, 28)
                 },
                 new Director
                 {
                     Name = "Steven",
                     LastName = "Spielberg",
                     BirthDate = new DateTime(1946, 12, 18)
                 },
                 new Director
                 {
                     Name = "Martin",
                     LastName = "Scorsese",
                     BirthDate = new DateTime(1942, 11, 17)
                 },
                 new Director
                 {
                     Name = "Quentin",
                     LastName = "Tarantino",
                     BirthDate = new DateTime(1963, 3, 27)
                 },
                 new Director
                 {
                     Name = "Christopher",
                     LastName = "Nolan",
                     BirthDate = new DateTime(1970, 7, 30)
                 },
                 new Director
                 {
                     Name = "James",
                     LastName = "Cameron",
                     BirthDate = new DateTime(1954, 8, 16)
                 },
                 new Director
                 {
                     Name = "Peter",
                     LastName = "Jackson",
                     BirthDate = new DateTime(1961, 10, 31)
                 },
                 new Director
                 {
                     Name = "Ridley",
                     LastName = "Scott",
                     BirthDate = new DateTime(1937, 11, 30)
                 },
                 new Director
                 {
                     Name = "Alfred",
                     LastName = "Hitchcock",
                     BirthDate = new DateTime(1899, 8, 13)
                 },
                 new Director
                 {
                     Name = "Stanley",
                     LastName = "Kubrick",
                     BirthDate = new DateTime(1928, 7, 26)
                 },
                 new Director
                 {
                     Name = "Francis Ford",
                     LastName = "Coppola",
                     BirthDate = new DateTime(1939, 4, 7)
                 },
                 new Director
                 {
                     Name = "Tim",
                     LastName = "Burton",
                     BirthDate = new DateTime(1958, 8, 25)
                 },
                 new Director
                 {
                     Name = "Clint",
                     LastName = "Eastwood",
                     BirthDate = new DateTime(1930, 5, 31)
                 },
                 new Director
                 {
                     Name = "Woody",
                     LastName = "Allen",
                     BirthDate = new DateTime(1935, 12, 1)
                 },
                 new Director
                 {
                     Name = "Sergio",
                     LastName = "Leone",
                     BirthDate = new DateTime(1929, 1, 3)
                 },
                 new Director
                 {
                     Name = "Joel",
                     LastName = "Coen",
                     BirthDate = new DateTime(1954, 11, 29)
                 },
                 new Director
                 {
                     Name = "Ethan",
                     LastName = "Coen",
                     BirthDate = new DateTime(1957, 9, 21)
                 },
                 new Director
                 {
                     Name = "David",
                     LastName = "Lynch",
                     BirthDate = new DateTime(1946, 1, 20)
                 },
                 new Director
                 {
                     Name = "Roman",
                     LastName = "Polanski",
                     BirthDate = new DateTime(1933, 8, 18)
                 },
                 new Director
                 {
                     Name = "Darren",
                     LastName = "Aronofsky",
                     BirthDate = new DateTime(1969, 2, 12)
                 }
             };

        var categories = new List<Category>
             {
                 new Category { Name = "Drama" },
                 new Category { Name = "Crime" },
                 new Category { Name = "Thriller" },
                 new Category { Name = "Action" },
                 new Category { Name = "Adventure" },
                 new Category { Name = "Sci-Fi" },
                 new Category { Name = "Fantasy" },
                 new Category { Name = "Mystery" },
                 new Category { Name = "Comedy" },
                 new Category { Name = "Romance" },
                 new Category { Name = "War" },
                 new Category { Name = "History" },
                 new Category { Name = "Biography" },
                 new Category { Name = "Western" },
                 new Category { Name = "Horror" },
                 new Category { Name = "Family" },
                 new Category { Name = "Animation" },
                 new Category { Name = "Music" },
                 new Category { Name = "Musical" },
                 new Category { Name = "Sport" },
                 new Category { Name = "Documentary" }
             };

        var productions = new List<Production>
             {
                 new Production { Name = "20th Century Fox" },
                 new Production { Name = "Warner Bros." },
                 new Production { Name = "Universal Pictures" },
                 new Production { Name = "Paramount Pictures" },
                 new Production { Name = "Columbia Pictures" },
                 new Production { Name = "Walt Disney Pictures" },
                 new Production { Name = "New Line Cinema" },
                 new Production { Name = "DreamWorks" },
                 new Production { Name = "Metro-Goldwyn-Mayer (MGM)" },
                 new Production { Name = "Touchstone Pictures" },
                 new Production { Name = "TriStar Pictures" },
                 new Production { Name = "Miramax" },
                 new Production { Name = "Lionsgate" },
                 new Production { Name = "Orion Pictures" },
                 new Production { Name = "Focus Features" },
                 new Production { Name = "United Artists" },
                 new Production { Name = "Fox Searchlight Pictures" },
                 new Production { Name = "Summit Entertainment" },
                 new Production { Name = "Dimension Films" },
                 new Production { Name = "Sony Pictures Classics" },
                 new Production { Name = "Screen Gems" },
                 new Production { Name = "Fox 2000 Pictures" },
                 new Production { Name = "New Regency Productions" },
                 new Production { Name = "Relativity Media" },
                 new Production { Name = "Working Title Films" },
                 new Production { Name = "Imagine Entertainment" },
                 new Production { Name = "Castle Rock Entertainment" },
                 new Production { Name = "Spyglass Entertainment" },
                 new Production { Name = "The Weinstein Company" },
                 new Production { Name = "StudioCanal" },
                 new Production { Name = "DreamWorks Animation" },
                 new Production { Name = "Lakeshore Entertainment" },
                 new Production { Name = "Participant Media" },
                 new Production { Name = "Legendary Entertainment" },
                 new Production { Name = "FilmDistrict" },
                 new Production { Name = "The Samuel Goldwyn Company" },
                 new Production { Name = "PolyGram Filmed Entertainment" },
                 new Production { Name = "A24" },
                 new Production { Name = "Columbia Pictures Corporation" }
             };

        var movies = new List<Movie>
             {
                 new Movie
                 {
                     Title = "Fight Club",
                     Duration = 139,
                     Released = new DateTime(1999, 10, 15),
                     Year = 1999,
                     Country = "USA",
                     Language = "English",
                     DirectorId = directors[0],
                     ProductionId = productions[0],
                     Actors =
                     [
                         actors[0],
                         actors[1],
                         actors[2],
                         actors[3],
                         actors[4],
                         actors[5],
                         actors[6],
                         actors[7]
                     ],
                     Categories =
                     [
                         categories[0],
                         categories[1],
                         categories[2]
                     ]
                 },
                 new Movie
                 {
                     Title = "The Curious Case of Benjamin Button",
                     Duration = 166,
                     Released = new DateTime(2009, 1, 16),
                     Year = 2008,
                     Country = "USA",
                     Language = "English",
                     DirectorId = directors[0],
                     ProductionId = productions[0],
                     Actors =
                     [
                         actors[0],
                         actors[8]
                     ],
                     Categories =
                     [
                         categories[0]
                     ],
                 },
                 new Movie
                 {
                     Title = "Seven",
                     Duration = 127,
                     Released = new DateTime(1995, 9, 22),
                     Year = 1995,
                     Country = "USA",
                     Language = "English",
                     DirectorId = directors[0],
                     ProductionId = productions[0],
                     Actors =
                     [
                         actors[0],
                         actors[9],
                         actors[10],
                         actors[11]
                     ],
                     Categories =
                     [
                         categories[0],
                         categories[1],
                         categories[2]
                     ]
                 }
             };

        db.Actors.AddRange(actors);
        db.Directors.AddRange(directors);
        db.Categories.AddRange(categories);
        db.Productions.AddRange(productions);
        db.Movies.AddRange(movies);
        db.SaveChanges();

        var movies = db.Movies
            .Include(m => m.Actors)
            .Include(m => m.Categories)
            .Include(m => m.Director)
            .Include(m => m.Production)
            .ToList();
    }
}
