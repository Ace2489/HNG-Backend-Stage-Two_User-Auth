using HNG_Backend_Stage_Two_User_Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace HNG_Backend_Stage_Two_User_Auth.Extensions;

public static class MigrationExtension
{
    public static IServiceCollection ApplyMigrations(this IServiceCollection services)
    {
        using var serviceScope = services.BuildServiceProvider().CreateScope();
        serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();

        return services;    
    }
}
