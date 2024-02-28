using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.Movies.MovieHistories;

namespace NetflixApi.Infrastructure.Repositories;

internal class MovieHistoryRepository : Repository<MovieHistory>, IMovieHistoryRepository
{
    public MovieHistoryRepository(IDbContextFactory<ApplicationDbContext> dbContext)
        : base(dbContext)
    {
    }
}
