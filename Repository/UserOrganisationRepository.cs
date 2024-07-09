using HNG_Backend_Stage_Two_User_Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace HNG_Backend_Stage_Two_User_Auth.Repository;

public interface IUserOrganisationRepository : IRepository<UserOrganisation>
{

}

public class UserOrganisationRepository(ApplicationDbContext context) : GenericRepository<UserOrganisation>(context), IUserOrganisationRepository
{
    private readonly ApplicationDbContext context = context;

}