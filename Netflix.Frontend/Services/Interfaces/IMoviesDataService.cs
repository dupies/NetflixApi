using Netflix.Frontend.Models;

namespace Netflix.Frontend.Services.Interfaces;

public interface IMoviesDataService
{
    Task<IEnumerable<MovieResponse>> GetAllMovies();
}
