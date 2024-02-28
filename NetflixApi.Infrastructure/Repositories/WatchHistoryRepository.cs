using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.WatchHistories;

namespace NetflixApi.Infrastructure.Repositories;

internal class WatchHistoryRepository : Repository<WatchHistory>, IWatchHistoryRepository
{
    public WatchHistoryRepository(IDbContextFactory<ApplicationDbContext> dbContext)
        : base(dbContext)
    {
    }
}
