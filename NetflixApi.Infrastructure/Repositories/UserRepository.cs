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
}