using HNG_Backend_Stage_Two_User_Auth.Models;

namespace HNG_Backend_Stage_Two_User_Auth;

public interface IUnitOfWork
{
    public Task SaveChangesAsync();
}
public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext context = context;

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
