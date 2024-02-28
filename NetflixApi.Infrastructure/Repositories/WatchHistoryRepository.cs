using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.Movies.MovieHistories;
using NetflixApi.Domain.WatchHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixApi.Infrastructure.Repositories;

internal class WatchHistoryRepository : Repository<WatchHistory>, IWatchHistoryRepository
{
    public WatchHistoryRepository(IDbContextFactory<ApplicationDbContext> dbContext)
        : base(dbContext)
    {
    }
}
