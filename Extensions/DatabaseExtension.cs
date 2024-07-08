using HNG_Backend_Stage_Two_User_Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace HNG_Backend_Stage_Two_User_Auth.Extensions;

public static class DatabaseExtension
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {

        string? connection = configuration.GetValue<string>("PG_Conn");
        ArgumentNullException.ThrowIfNull(connection);

        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseNpgsql(connection);
            if (env.IsDevelopment() || env.IsStaging())
            {
                opt.EnableDetailedErrors();
            }
        });

        return services;
    }
}
