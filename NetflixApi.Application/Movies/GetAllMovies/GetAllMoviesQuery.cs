using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Application.Movies.GetMovies;

namespace NetflixApi.Application.Movies.GetAllMovies;

public record GetAllMoviesQuery(int GenreId) : IQuery<ICollection<MovieResponse>>;