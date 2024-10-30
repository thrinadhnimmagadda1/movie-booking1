public class MovieController : IMovieController
{
    private List<Movie> movies = new List<Movie>
    {
        new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", Description = "A mind-bending thriller", ShowTime = "2023-10-01T20:00:00" },
        new Movie { Id = 2, Title = "The Matrix", Genre = "Action", Description = "A hacker discovers reality", ShowTime = "2023-10-02T22:00:00" }
    };
    // GET call.
    public async Task<IEnumerable<Movie>> GetMovies()
    {
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
        return await Task.FromResult(true);
    }

    // DELTETE call
    public async Task<bool> RemoveMovie(Movie movie)
    {
        if (movie == null)
        {
            return await Task.FromResult(false);
        }
        return await Task.FromResult(movies.Remove(movie));
    }
}
