namespace NetflixApi.Domain.Abstractions;

public interface IRepository<T>
    where T : Entity
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
    Task Add(T entity);
    Task Update(T entity);
}
