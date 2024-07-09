using HNG_Backend_Stage_Two_User_Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace HNG_Backend_Stage_Two_User_Auth.Repository;

public interface IOrganisationRepository : IRepository<Organisation>
{

}

public class OrganisationRepository(ApplicationDbContext context) : GenericRepository<Organisation>(context), IOrganisationRepository
{
    private readonly ApplicationDbContext context = context;

}