namespace NetflixApi.Domain.WatchHistories;

public interface IWatchHistoryRepository
{
    Task Add(WatchHistory entity);
}
