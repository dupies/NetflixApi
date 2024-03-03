using NetflixApi.Application.Movies.GetMovies;

namespace NetflixApi.Application.Movies.GetAllMovies;

public record AllMoviesResponse(ICollection<MovieResponse> Movies);