﻿using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.Users;

namespace NetflixApi.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : base(contextFactory)
    {
    }

    public Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetDetailsByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        using (var context = await this._contextFactory.CreateDbContextAsync())
        {
            var result = await context.Users.FindAsync(id);

            var movieHistories = await context.MovieHistories.Where(h => h.UserId == id).ToListAsync();
            result.MovieHistories = movieHistories;

            return result;
        }
    }
}
