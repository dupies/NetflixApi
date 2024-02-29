using NetflixApi.Application.Movies.GetMovies;
using NetflixApi.Application.TVShows.GetTVShow;
using NetflixApi.Domain.WatchHistories;

namespace NetflixApi.Application.WatchHistories.GetUserWatchHistories;

public record UserWatchHistoriesResponse(
    int UserId,
    int ShowId,
    ShowType Type,
    MovieResponse? Movie,
    TVShowResponse? TVShow
    );