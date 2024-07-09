using HNG_Backend_Stage_Two_User_Auth.Configuration;
using HNG_Backend_Stage_Two_User_Auth.Models;
using HNG_Backend_Stage_Two_User_Auth.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HNG_Backend_Stage_Two_User_Auth.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IUserService, UserService>()
        .AddScoped<IUnitOfWork, UnitOfWork>()
        .AddScoped<IAuthService, AuthService>()
        .AddScoped<IPasswordHasher<User>, PasswordHasher<User>>()
        
        .AddScoped<IOrganisationRepository, OrganisationRepository>()
        .AddScoped<IOrganisationService, OrganisationService>()
        .AddScoped<IUserOrganisationRepository, UserOrganisationRepository>()
        .AddScoped<IUserOrganisationService, UserOrganisationService>()
        ;

        return services;
    }
}
