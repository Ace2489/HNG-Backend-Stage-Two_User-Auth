using HNG_Backend_Stage_Two_User_Auth.Repository;

namespace HNG_Backend_Stage_Two_User_Auth;

public interface IUserOrganisationService : IService<UserOrganisation>
{
    public Task<UserOrganisation> AddUserToOrganisationAsync(string userId, string organisationId, CancellationToken cancellationToken = default);
}

public sealed class UserOrganisationService(IUserOrganisationRepository repository) : GenericService<UserOrganisation>(repository), IUserOrganisationService
{
    private readonly IUserOrganisationRepository repository = repository;

    public async Task<UserOrganisation> AddUserToOrganisationAsync(string userId, string organisationId, CancellationToken cancellationToken = default)
    {
        UserOrganisation userOrganisation = new()
        {
            UserId = userId,
            OrgId = organisationId,
        };
        return await repository.AddAsync(userOrganisation, cancellationToken);
    }
}
