using HNG_Backend_Stage_Two_User_Auth.Models;
using HNG_Backend_Stage_Two_User_Auth.Repository;

namespace HNG_Backend_Stage_Two_User_Auth;

public interface IUserService : IService<User>
{
    public Task<bool> DoesUserExist(string email, CancellationToken cancellationToken = default);

    public Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);

}

public sealed class UserService(IUserRepository repository) : GenericService<User>(repository), IUserService
{
    private readonly IUserRepository repository = repository;

    public async Task<bool> DoesUserExist(string email, CancellationToken cancellationToken = default)
    {
        return await repository.DoesUserExist(email, cancellationToken);
    }

    public Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return repository.FindByAsync(u => u.Email == email, cancellationToken);
    }
}
