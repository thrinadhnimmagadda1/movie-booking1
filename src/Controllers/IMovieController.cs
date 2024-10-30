using System.Collections.Generic;
using MovieReviewApi.Models;

namespace SimpleRestApi.Repositories
{
	public interface IMovieController
	{
		IEnumerable<Movie> GetMovies(); // GET
		bool AddMovie(Movie movie); // POST
		bool RemoveMovie(Movie movie); // DELETE

    }
}
