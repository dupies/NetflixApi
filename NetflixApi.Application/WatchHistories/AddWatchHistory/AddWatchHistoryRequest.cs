using NetflixApi.Domain.WatchHistories;

namespace NetflixApi.Application.WatchHistories.AddWatchHistory;
public record AddWatchHistoryRequest(
    int UserId,
    int ShowId,
    ShowType Type
    );