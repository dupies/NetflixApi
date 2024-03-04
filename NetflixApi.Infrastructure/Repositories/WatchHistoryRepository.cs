using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.WatchHistories;

namespace NetflixApi.Infrastructure.Repositories;

internal class WatchHistoryRepository : Repository<WatchHistory>, IWatchHistoryRepository
{
    public WatchHistoryRepository(IDbContextFactory<ApplicationDbContext> dbContext)
        : base(dbContext)
    {

    }

    public async Task<ICollection<WatchHistory>> GetUsersWatchHistories(int userId, CancellationToken cancellationToken)
    {
        using (var context = await this._contextFactory.CreateDbContextAsync())
        {
            var result = await context.WatchHistories.Where(wh => wh.UserId == userId).ToListAsync();
            
            foreach(var watchHistory in  result)
            {
                switch (watchHistory.Type)
                {
                    case ShowType.Movie:
                        var movie = await context.Movies.FindAsync(watchHistory.ShowId);
                        watchHistory.Movie = movie;
                        break;
                    case ShowType.TVShow:
                        var tvShow = await context.TVShows.FindAsync(watchHistory.ShowId);
                        watchHistory.TVShow = tvShow;
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }

}
