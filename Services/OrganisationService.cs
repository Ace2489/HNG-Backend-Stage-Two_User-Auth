using HNG_Backend_Stage_Two_User_Auth.Models;
using HNG_Backend_Stage_Two_User_Auth.Repository;

namespace HNG_Backend_Stage_Two_User_Auth;

public interface IOrganisationService : IService<Organisation>
{

}

public sealed class OrganisationService(IOrganisationRepository repository) : GenericService<Organisation>(repository), IOrganisationService
{
    private readonly IOrganisationRepository repository = repository;
}
