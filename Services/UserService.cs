using HNG_Backend_Stage_Two_User_Auth.Models;
using HNG_Backend_Stage_Two_User_Auth.Repository;

namespace HNG_Backend_Stage_Two_User_Auth;

public interface IUserService : IService<User>
{

}

public sealed class UserService(IUserRepository repository, IUnitOfWork unitOfWork) : GenericService<User>(repository), IUserService
{
    private readonly IUserRepository repository = repository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

}
