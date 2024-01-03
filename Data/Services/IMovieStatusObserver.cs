using CinemaTickets.Models;

namespace CinemaTickets.Data.Services
{
    public interface IMovieStatusObserver
    {
        void UpdateMovieStatus(Movie movie);
    }
}
