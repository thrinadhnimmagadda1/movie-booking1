using System.Collections.Generic;
using System.Threading.Tasks;
using MovieReviewApi.Models;

namespace SimpleRestApi.Repositories {

	public interface ITicketController {
		Task<IEnumerable<Ticket>> GetTickets(int movieId); // GET
	}
}