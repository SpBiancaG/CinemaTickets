using CinemaTickets.Data.Base;
using CinemaTickets.Models;

namespace CinemaTickets.Data.Services
{
	public class ProducersService: EntityBaseRepository<Producer>, IProducersService
	{
		public ProducersService(AppDbContext context) : base(context) { }
	}
}
