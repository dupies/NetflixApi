using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.Abstractions;

namespace NetflixApi.Infrastructure.Repositories;

internal abstract class Repository<T>
where T : Entity
{
    protected readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public void Initialize()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            context.Database.EnsureCreated();
        }
    }
    protected Repository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = default(T);
        using (var context = await this._contextFactory.CreateDbContextAsync())
        {
            result = await context.FindAsync<T>(id);

            if (result == null)
            {
                return default(T);
            }
        }

        return result;
    }

    public async Task Add(T entity)
    {
        using (var context = await this._contextFactory.CreateDbContextAsync())
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(T entity)
    {
        using (var context = await this._contextFactory.CreateDbContextAsync())
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}