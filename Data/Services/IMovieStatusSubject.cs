using CinemaTickets.Models;

namespace CinemaTickets.Data.Services
{
    public interface IMovieStatusSubject
    {
        void RegisterObserver(IMovieStatusObserver observer);
        void RemoveObserver(IMovieStatusObserver observer);
        void NotifyObservers(Movie movie);
    }
}
