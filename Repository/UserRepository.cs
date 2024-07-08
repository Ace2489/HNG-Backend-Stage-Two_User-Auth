using HNG_Backend_Stage_Two_User_Auth.Models;

namespace HNG_Backend_Stage_Two_User_Auth.Repository;

public interface IUserRepository : IRepository<User>
{

}

public class UserRepository(ApplicationDbContext context) : GenericRepository<User>(context), IUserRepository
{

}