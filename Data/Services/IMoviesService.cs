using CinemaTickets.Data.Base;
using CinemaTickets.Data.ViewModels;
using CinemaTickets.Models;
using System.Threading.Tasks;
namespace CinemaTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownVM> GetNewMovieDropdownsValues();

        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}