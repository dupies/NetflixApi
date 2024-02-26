using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.TVShows;

namespace NetflixApi.Infrastructure.Repositories;

internal sealed class TVShowRepository : Repository<TVShow>, ITVShowRespository
{
    public TVShowRepository(IDbContextFactory<ApplicationDbContext> dbContext)
        : base(dbContext)
    {
    }

    public Task<IEnumerable<TVShow>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
