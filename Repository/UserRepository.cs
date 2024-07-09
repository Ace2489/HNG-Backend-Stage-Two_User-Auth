using HNG_Backend_Stage_Two_User_Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace HNG_Backend_Stage_Two_User_Auth.Repository;

public interface IUserRepository : IRepository<User>
{
    public Task<bool> DoesUserExist(string email, CancellationToken cancellationToken = default);

}

public class UserRepository(ApplicationDbContext context) : GenericRepository<User>(context), IUserRepository
{
    private readonly ApplicationDbContext context = context;

    public Task<bool> DoesUserExist(string email, CancellationToken cancellationToken = default)
    {
        return context.Users.AnyAsync(e => e.Email == email, cancellationToken);
    }
}