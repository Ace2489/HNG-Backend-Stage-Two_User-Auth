using HNG_Backend_Stage_Two_User_Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace HNG_Backend_Stage_Two_User_Auth.Repository;

public interface IRepository<T> where T : class
{
    public Task<T?> FindAsync(string Id, CancellationToken cancellationToken = default);

    public Task<T?> AddAsync(T entity, CancellationToken cancellationToken = default);

}

public abstract class GenericRepository<T>(ApplicationDbContext context) : IRepository<T> where T : class
{

    private readonly DbSet<T> context = context.Set<T>();

    public async Task<T?> FindAsync(string Id, CancellationToken cancellationToken = default)
    {
        return await context.FindAsync([Id], cancellationToken);
    }

    public async Task<T?> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await context.AddAsync(entity, cancellationToken);
        
        return entity;
    }
}
