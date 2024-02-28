using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.Movies;

namespace NetflixApi.Infrastructure.Repositories;

internal sealed class MovieRepository : Repository<Movie>, IMovieRepository
{
    public MovieRepository(IDbContextFactory<ApplicationDbContext> dbContext)
        : base(dbContext)
    {
    }

    public Task<IEnumerable<Movie>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
