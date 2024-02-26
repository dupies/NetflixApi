using NetflixApi.Application.Abstractions.Messaging;

namespace NetflixApi.Application.TVShows.GetTVShow;

public sealed record GetTVShowQuery(int TVShowId) : IQuery<TVShowResponse>;

