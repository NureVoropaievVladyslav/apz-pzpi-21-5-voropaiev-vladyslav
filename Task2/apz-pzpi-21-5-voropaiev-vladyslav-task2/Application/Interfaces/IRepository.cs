namespace Application.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity, CancellationToken cancellationToken);

    void Update(T entity);

    void Delete(T entity);

    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken);

    Task<List<T>> GetAsync(CancellationToken cancellationToken);

    IQueryable<T> GetQueryable();
}