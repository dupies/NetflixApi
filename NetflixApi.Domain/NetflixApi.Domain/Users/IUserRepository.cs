using NetflixApi.Domain.Abstractions;

namespace NetflixApi.Domain.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetDetailsByIdAsync(int id, CancellationToken cancellationToken = default);
}
