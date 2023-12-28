using CinemaTickets.Data.Base;
using CinemaTickets.Data.ViewModels;
using CinemaTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace CinemaTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId
            };

            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //add actors to movie join tables

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie
                {
                    ActorId = actorId,
                    MovieId = newMovie.Id
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();




        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return await movieDetails;
        }
        public async Task<NewMovieDropdownVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownVM();
            response.Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync();
            response.Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync();
            response.Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync();
            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();

            }

            //stergem actorii deja existenti
            var existingActors = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActors);
            await _context.SaveChangesAsync();




            //add actors to movie join tables

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie
                {
                    ActorId = actorId,
                    MovieId = data.Id
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}