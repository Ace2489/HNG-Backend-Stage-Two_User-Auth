using HNG_Backend_Stage_Two_User_Auth.Models;
using HNG_Backend_Stage_Two_User_Auth.Repository;

namespace HNG_Backend_Stage_Two_User_Auth;


public interface IService<T>
{
    public Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    public Task<T?> FindAsync(string Id, CancellationToken cancellationToken = default);
}

public abstract class GenericService<T>(IRepository<T> repository) : IService<T> where T : class
{
    private readonly IRepository<T> repository = repository;

    public Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        return repository.AddAsync(entity, cancellationToken);
    }

    public Task<T?> FindAsync(string Id, CancellationToken cancellationToken = default)
    {
        return repository.FindAsync(Id, cancellationToken);
    }
}
