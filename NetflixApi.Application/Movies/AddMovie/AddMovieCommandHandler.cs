using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Application.TVShows.AddTVShow;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Movies;
using NetflixApi.Domain.TVShows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NetflixApi.Application.Movies.AddMovie;

internal sealed class AddMovieCommandHandler : ICommandHandler<AddMovieCommand, int>
{
    private readonly IMovieRepository _movieRepository;

    public AddMovieCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<Result<int>> Handle(AddMovieCommand command
        , CancellationToken cancellationToken)
    {
        var movie = new Movie(
        command.request.Id,
            command.request.Adult,
            command.request.Backdrop_path,
            command.request.Genre_ids,
            command.request.Original_language,
            command.request.Original_title,
            command.request.Overview,
            command.request.Popularity,
            command.request.Poster_path,
            command.request.Release_date,
            command.request.Title,
            command.request.Video,
            command.request.Vote_average,
            command.request.Vote_count
            );

        await _movieRepository.Add(movie);

        return movie.Id;
    }
}
