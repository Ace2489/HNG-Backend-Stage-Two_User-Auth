using HNG_Backend_Stage_Two_User_Auth.Models;
using HNG_Backend_Stage_Two_User_Auth.Repository;

namespace HNG_Backend_Stage_Two_User_Auth;


public interface IService<T>
{
    public Task<T?> FindAsync(string Id);
}

public abstract class GenericService<T>(IRepository<T> repository) : IService<T> where T : class
{
    public Task<T?> FindAsync(string Id)
    {
        throw new NotImplementedException();
    }
}
