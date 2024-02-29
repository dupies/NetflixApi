using NetflixApi.Application.Abstractions.Messaging;

namespace NetflixApi.Application.WatchHistories.GetUserWatchHistories;

public record GetUserWatchHistoriesQuery(int userId) : IQuery<ICollection<UserWatchHistoriesResponse>>;
