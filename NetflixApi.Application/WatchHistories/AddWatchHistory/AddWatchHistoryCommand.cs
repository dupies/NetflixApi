using NetflixApi.Application.Abstractions.Messaging;

namespace NetflixApi.Application.WatchHistories.AddWatchHistory;
public record AddWatchHistoryCommand(AddWatchHistoryRequest request) : ICommand<int>;
