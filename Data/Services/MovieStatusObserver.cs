using CinemaTickets.Data.Services;
using CinemaTickets.Models;
using System;

public class MovieStatusObserver : IMovieStatusObserver
{
    public void UpdateMovieStatus(Movie movie)
    {
        // Implement the logic to handle movie status change notification
        Console.WriteLine($"Movie status changed for '{movie.Name}' - New Status: {GetMovieStatus(movie)}");
    }

    private string GetMovieStatus(Movie movie)
    {
        if (DateTime.Now >= movie.StartDate && DateTime.Now <= movie.EndDate)
        {
            return "AVAILABLE";
        }
        else if (DateTime.Now > movie.EndDate)
        {
            return "EXPIRED";
        }
        else
        {
            return "UPCOMING";
        }
    }
}
