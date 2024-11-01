using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase, ITicketController
{
    // private readonly ApplicationDbContext _context;
    // public TicketController(ApplicationDbContext context)
    // {
    //     _context = context;
    // }

    // In-memory list for carts ~ temporary
    private List<Ticket> tickets = new List<Ticket>
    {
        new Ticket { Id = 1, MovieId = 1, SeatNumber = 1, Price = 10.00m },
        new Ticket { Id = 2, MovieId = 1, SeatNumber = 2, Price = 10.00m },
        new Ticket { Id = 3, MovieId = 2, SeatNumber = 1, Price = 12.50m },
    };

    // GET: api/ticket/movie/{movieId}
    [HttpGet("movie/{movieId}")]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets(int movieId)
    {
        // var ticketsForMovie = await _context.Tickets.Where(t => t.MovieId == movieId).ToListAsync();
        // if (!ticketsForMovie.Any())
        // {
        //     return NotFound(new { Message = "No tickets found for the specified movie" }); // 404 Not Found
        // }
        // return Ok(ticketsForMovie); // 200 OK with list of tickets

        // In-memory list for carts ~ temporary
        var ticketsForMovie = tickets.Where(t => t.MovieId == movieId).ToList();
        if (!ticketsForMovie.Any())
        {
            return NotFound(new { Message = "No tickets found for the specified movie" });
        }
        return Ok(ticketsForMovie);
    }
}
