using CinemaTickets.Data.Base;
using CinemaTickets.Models;

namespace CinemaTickets.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {

        }
    }
}
