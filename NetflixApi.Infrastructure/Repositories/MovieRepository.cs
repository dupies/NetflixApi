using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.Movies;
using System.ComponentModel;

namespace NetflixApi.Infrastructure.Repositories;

internal sealed class MovieRepository : Repository<Movie>, IMovieRepository
{
    public MovieRepository(IDbContextFactory<ApplicationDbContext> dbContext)
        : base(dbContext)
    {
    }

    public async Task<IEnumerable<Movie>> GetAll(int queryId = 0, CancellationToken cancellationToken = default)
    {
        if(queryId == 0)
        {
            using (var context = await this._contextFactory.CreateDbContextAsync())
            {
                var result = await context.Movies.OrderByDescending(m => m.Vote_average).ToListAsync();

                return result;
            }
        }
        else
        {
            using (var context = await this._contextFactory.CreateDbContextAsync())
            {
                var result = await context.Movies.Where(c => c.Genre_ids.Contains(queryId)).ToListAsync();

                return result;
            }
        }
        
    }
}
