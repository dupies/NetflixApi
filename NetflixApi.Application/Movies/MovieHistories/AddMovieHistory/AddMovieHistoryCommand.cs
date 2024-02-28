using NetflixApi.Application.Abstractions.Messaging;

namespace NetflixApi.Application.Movies.MovieHistories.AddWatchHistory;

public record AddMovieHistoryCommand(AddMovieHistoryRequest request) : ICommand<int>;