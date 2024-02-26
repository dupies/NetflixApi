using NetflixApi.Application.Abstractions.Messaging;

namespace NetflixApi.Application.Movies.AddMovie;

public record AddMovieCommand(AddMovieRequest request)  : ICommand<int>;