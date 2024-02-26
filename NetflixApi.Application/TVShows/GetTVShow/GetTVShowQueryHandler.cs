using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.TVShows;

namespace NetflixApi.Application.TVShows.GetTVShow;

internal sealed class GetTVShowQueryHandler : IQueryHandler<GetTVShowQuery, TVShowResponse>
{
    private readonly ITVShowRespository _tVShowRespository;

    public GetTVShowQueryHandler(ITVShowRespository tVShowRespository)
    {
        _tVShowRespository = tVShowRespository;
    }

    public async Task<Result<TVShowResponse>> Handle(GetTVShowQuery request, CancellationToken cancellationToken)
    {
        var result = await _tVShowRespository.GetByIdAsync(request.TVShowId, cancellationToken);
        if(result != null)
        {
            var response = new TVShowResponse(
                result.Id,
                result.Adult,
                result.Backdrop_path.Value,
                result.Genre_ids,
                result.Origin_country,
                result.Original_language.Value,
                result.Original_name.Value,
                result.Overview.Value,
                result.Popularity.Value,
                result.Poster_path.Value,
                result.First_air_date.Value,
                result.Name.Value,
                result.Vote_average.Value,
                result.Vote_count.Value);

            return response;
        }
        else
        {
            return Result.Failure<TVShowResponse>(TVShowErrors.NotFound);
        }
    }
}
