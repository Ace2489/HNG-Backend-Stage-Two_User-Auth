using HNG_Backend_Stage_Two_User_Auth.Models;
using HNG_Backend_Stage_Two_User_Auth.Repository;
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
        ;

        return services;
    }
}
