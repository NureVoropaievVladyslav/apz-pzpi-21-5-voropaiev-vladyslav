namespace Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext Context;

    public Repository(ApplicationDbContext context)
    {
        Context = context;
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await Context.AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        Context.Update(entity);
    }

    public void Delete(T entity)
    {
        Context.Remove(entity);
    }

    public Task<T?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }

    public Task<List<T>> GetAsync(CancellationToken cancellationToken)
    {
        return Context.Set<T>().ToListAsync();
    }

    public IQueryable<T> GetQueryable()
    {
        return Context.Set<T>();
    }
}