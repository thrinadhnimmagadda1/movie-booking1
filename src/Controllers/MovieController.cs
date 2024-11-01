using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase, IMovieController
{
    // private readonly ApplicationDbContext _context;
    // public MovieController(ApplicationDbContext context)
    // {
    //     _context = context;
    // }

    // In-memory list for tickets (temporary, for testing without a database)
    private List<Movie> movies = new List<Movie>
    {
        new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", Description = "A mind-bending thriller", ShowTime = "2023-10-01T20:00:00" },
        new Movie { Id = 2, Title = "The Matrix", Genre = "Action", Description = "A hacker discovers reality", ShowTime = "2023-10-02T22:00:00" }
    };
    // GET call.
    public async Task<IEnumerable<Movie>> GetMovies()
    {
        // return await _context.Movies.ToListAsync(); // Asynchronously fetch all movies
        return await Task.FromResult(movies);
    }

    // POST call.
    public async Task<bool> AddMovie(Movie movie)
    {
        if (movie == null)
        {
            return await Task.FromResult(false);
        }
        movies.Add(movie);
        // _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }

    // DELTETE call
    public async Task<bool> RemoveMovie(Movie movie)
    {
        if (movie == null)
        {
            return await Task.FromResult(false);
        }
        // _context.Movies.Remove(movie);
        // var changes = await _context.SaveChangesAsync(); // Save changes to the database
        // return changes > 0; // Return true if deletion was successful
        return await Task.FromResult(movies.Remove(movie));
    }
}
