namespace NetflixApi.Domain.WatchHistories;

public interface IWatchHistoryRepository
{
    Task Add(WatchHistory entity);
    Task<ICollection<WatchHistory>> GetUsersWatchHistories(int userId, CancellationToken cancellationToken);
}
