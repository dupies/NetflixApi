using NetflixApi.Domain.Movies.MovieHistories;

namespace NetflixApi.Application.Movies.MovieHistories.AddWatchHistory;

public record AddMovieHistoryRequest(
    int UserId,
    int MovieId,
    DateTimeOffset Date
    );
