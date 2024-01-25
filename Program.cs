using FilmWebApi.Entities;
using FilmWebApi.Repositories;
using FilmWebApi.Services;
using Microsoft.AspNetCore.Identity;
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

        builder.Services.AddScoped<IActorService, ActorService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IDirectorService, DirectorService>();
        builder.Services.AddScoped<IMovieService, MovieService>();
        builder.Services.AddScoped<IProductionService, ProductionService>();

        builder.Services.AddScoped<ActorRepository>();
        builder.Services.AddScoped<CategoryRepository>();
        builder.Services.AddScoped<DirectorRepository>();
        builder.Services.AddScoped<MovieRepository>();
        builder.Services.AddScoped<ProductionRepository>();

        builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationContext>();
        
        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationContext"));
        });

        builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddCookie(IdentityConstants.ApplicationScheme, options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        // app.UseMiddleware<MobileUserAgentMiddleware>();
                
        Populate();

        app.Run();

    }

    private static void Populate()
    {
        try
        {
            var db = new ApplicationContext();
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
                    Name = "Stephen",
                    LastName = "Lang",
                    BirthDate = new DateTime(1952, 7, 11)
                },
                new Actor
                {
                    Name = "Dylan",
                    LastName = "O'Brien",
                    BirthDate = new DateTime(1991, 8, 26)
                },
                new Actor
                {
                    Name = "Aml",
                    LastName = "Ameen",
                    BirthDate = new DateTime(1985, 7, 30)
                },
                new Actor
                {
                    Name = "Ki",
                    LastName = "Hong Lee",
                    BirthDate = new DateTime(1986, 9, 30)
                },
                new Actor
                {
                    Name = "Kaya",
                    LastName = "Scodelario",
                    BirthDate = new DateTime(1992, 3, 13)
                },
                new Actor
                {
                    Name = "Thomas",
                    LastName = "Brodie",
                    BirthDate = new DateTime(1990, 8, 8)
                },
                new Actor
                {
                    Name = "Will",
                    LastName = "Poulter",
                    BirthDate = new DateTime(1993, 1, 28)
                },
                new Actor
                {
                    Name = "Patricia",
                    LastName = "Clarkson",
                    BirthDate = new DateTime(1959, 12, 29)
                },
                new Actor
                {
                    Name = "Katherine",
                    LastName = "McNamara",
                    BirthDate = new DateTime(1995, 11, 22)
                },
                new Actor
                {
                    Name = "Thomas",
                    LastName = "Sangster",
                    BirthDate = new DateTime(1990, 5, 16)
                },
                new Actor
                {
                    Name = "Jacob",
                    LastName = "Lofland",
                    BirthDate = new DateTime(1996, 7, 30)
                },
                new Actor
                {
                    Name = "Rosa",
                    LastName = "Salazar",
                    BirthDate = new DateTime(1985, 7, 16)
                },
                new Actor
                {
                    Name = "Giancarlo",
                    LastName = "Esposito",
                    BirthDate = new DateTime(1958, 4, 26)
                },
                new Actor
                {
                    Name = "Aidan",
                    LastName = "Gillen",
                    BirthDate = new DateTime(1968, 4, 24)
                },
                new Actor
                {
                    Name = "Barry",
                    LastName = "Pepper",
                    BirthDate = new DateTime(1970, 4, 4)
                },
                new Actor
                {
                    Name = "Lili",
                    LastName = "Taylor",
                    BirthDate = new DateTime(1967, 2, 20)
                },
                new Actor
                {
                    Name = "Patricia",
                    LastName = "Clarkson",
                    BirthDate = new DateTime(1959, 12, 29)
                },
                new Actor
                {
                    Name = "Thomas",
                    LastName = "Sangster",
                    BirthDate = new DateTime(1990, 5, 16)
                },
                new Actor
                {
                    Name = "Jacob",
                    LastName = "Lofland",
                    BirthDate = new DateTime(1996, 7, 30)
                },
                new Actor
                {
                    Name = "Rosa",
                    LastName = "Salazar",
                    BirthDate = new DateTime(1985, 7, 16)
                },
                new Actor
                {
                    Name = "Giancarlo",
                    LastName = "Esposito",
                    BirthDate = new DateTime(1958, 4, 26)
                },
                new Actor
                {
                    Name = "Aidan",
                    LastName = "Gillen",
                    BirthDate = new DateTime(1968, 4, 24)
                },
                new Actor
                {
                    Name = "Barry",
                    LastName = "Pepper",
                    BirthDate = new DateTime(1970, 4, 4)
                }
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
                    Director = directors[0],
                    Production = productions[0],
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
                    Director = directors[0],
                    Production = productions[0],
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
                    Director = directors[0],
                    Production = productions[0],
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
                },
                new Movie
                {
                    Title = "The Game",
                    Duration = 129,
                    Released = new DateTime(1997, 9, 12),
                    Year = 1997,
                    Country = "USA",
                    Language = "English",
                    Director = directors[0],
                    Production = productions[0],
                    Actors =
                    [
                        actors[0],
                        actors[12]
                    ],
                    Categories =
                    [
                        categories[0],
                        categories[2],
                        categories[3]
                    ]
                },
                new Movie
                {
                    Title = "The Social Network",
                    Duration = 120,
                    Released = new DateTime(2010, 10, 1),
                    Year = 2010,
                    Country = "USA",
                    Language = "English",
                    Director = directors[0],
                    Production = productions[0],
                    Actors =
                    [
                        actors[0],
                        actors[13]
                    ],
                    Categories =
                    [
                        categories[0],
                        categories[3],
                        categories[4]
                    ]
                },
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    Duration = 142,
                    Released = new DateTime(1994, 10, 14),
                    Year = 1994,
                    Country = "USA",
                    Language = "English",
                    Director = directors[1],
                    Production = productions[1],
                    Actors =
                    [
                        actors[14],
                        actors[15],
                        actors[16]
                    ],
                    Categories =
                    [
                        categories[0],
                        categories[1],
                        categories[5]
                    ]
                },
                new Movie
                {
                    Title = "Schindler's List",
                    Duration = 195,
                    Released = new DateTime(1994, 2, 4),
                    Year = 1993,
                    Country = "USA",
                    Language = "English",
                    Director = directors[1],
                    Production = productions[1],
                    Actors =
                    [
                        actors[17],
                        actors[18],
                        actors[19]
                    ],
                    Categories =
                    [
                        categories[0],
                        categories[5],
                        categories[10]
                    ]
                },
                new Movie
                {
                    Title = "Saving Private Ryan",
                    Duration = 169,
                    Released = new DateTime(1998, 7, 24),
                    Year = 1998,
                    Country = "USA",
                    Language = "English",
                    Director = directors[1],
                    Production = productions[1],
                    Actors =
                    [
                        actors[17],
                        actors[20],
                        actors[21]
                    ],
                    Categories =
                    [
                        categories[0],
                        categories[3],
                        categories[10]
                    ]
                },
                new Movie
                {
                    Title = "Catch Me If You Can",
                    Duration = 141,
                    Released = new DateTime(2003, 1, 31),
                    Year = 2002,
                    Country = "USA",
                    Language = "English",
                    Director = directors[1],
                    Production = productions[1],
                    Actors =
                    [
                        actors[17],
                        actors[22]
                    ],
                    Categories =
                    [
                        categories[0],
                        categories[3],
                        categories[4]
                    ]
                },
                new Movie
                {
                    Title = "The Terminal",
                    Duration = 128,
                    Released = new DateTime(2004, 7, 9),
                    Year = 2004,
                    Country = "USA",
                    Language = "English",
                    Director = directors[1],
                    Production = productions[1],
                    Actors =
                    [
                        actors[17],
                        actors[23]
                    ],
                    Categories =
                    [
                        categories[0],
                        categories[3],
                        categories[4]
                    ]
                },
                new Movie
                {
                    Title = "The Godfather",
                    Duration = 175,
                    Released = new DateTime(1972, 3, 24),
                    Year = 1972,
                    Country = "USA",
                    Language = "English",
                    Director = directors[2],
                    Production = productions[2],
                    Actors =
                    [
                        actors[24],
                        actors[25],
                        actors[26]
                    ],
                    Categories =
                    [
                        categories[0],
                        categories[1],
                        categories[10]
                    ]
                },
                new Movie
                {
                    Title = "The Godfather: Part II",
                    Duration = 202,
                    Released = new DateTime(1974, 12, 20),
                    Year = 1974,
                    Country = "USA",
                    Language = "English",
                    Director = directors[2],
                    Production = productions[2],
                    Actors =
                    [
                        actors[24],
                        actors[25],
                        actors[27]
                    ],
                    Categories =
                    [
                        categories[0],
                        categories[1],
                        categories[10]
                    ]
                },
                new Movie
                {
                    Title = "The Godfather: Part III",
                    Duration = 162,
                    Released = new DateTime(1991, 12, 25),
                    Year = 1990,
                    Country = "USA",
                    Language = "English",
                    Director = directors[2],
                    Production = productions[2],
                    Actors =
                    [
                        actors[24],
                        actors[28],
                        actors[29]
                    ],
                    Categories =
                    [
                        categories[0],
                        categories[1],
                        categories[10]
                    ]
                }
            };

            db.Actors.AddRange(actors);
            db.Directors.AddRange(directors);
            db.Categories.AddRange(categories);
            db.Productions.AddRange(productions);
            db.Movies.AddRange(movies);

            db.SaveChanges();

            Console.WriteLine("Database populated");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
