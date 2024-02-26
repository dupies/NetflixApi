using NetflixApi.Application.Abstractions.Messaging;

namespace NetflixApi.Application.Movies.GetMovies;
public sealed record GetMovieQuery(int TVShowId) : IQuery<MovieResponse>;