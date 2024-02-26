using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.TVShows;

namespace NetflixApi.Application.TVShows.AddTVShow;

internal sealed class AddTVShowCommandHandler : ICommandHandler<AddTVShowCommand, int>
{
    private readonly ITVShowRespository _tVShowRespository;

    public AddTVShowCommandHandler(ITVShowRespository tVShowRespository)
    {
        _tVShowRespository = tVShowRespository;
    }

    public async Task<Result<int>> Handle(AddTVShowCommand command, CancellationToken cancellationToken)
    {
        var tvShow = new TVShow(
            command.request.Id,
            command.request.Adult,
            command.request.Backdrop_path,
            command.request.Genre_ids,
            command.request.Origin_country,
            command.request.Original_language,
            command.request.Original_name,
            command.request.Overview,
            command.request.Popularity,
            command.request.Poster_path,
            command.request.First_air_date,
            command.request.Name,
            command.request.Vote_average,
            command.request.Vote_count
            );

        await _tVShowRespository.Add(tvShow);

        return tvShow.Id;
    }
}
