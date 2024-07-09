using System.Security.Claims;
using System.Text;
using HNG_Backend_Stage_Two_User_Auth.Configuration;
using HNG_Backend_Stage_Two_User_Auth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace HNG_Backend_Stage_Two_User_Auth.Extensions;

public static class JwtAuthenticationExtension
{
    public static WebApplicationBuilder AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        Jwt jwtOptions = builder.Configuration.GetSection(nameof(Jwt)).Get<Jwt>()!;

        builder.Services.Configure<Jwt>(builder.Configuration.GetSection(nameof(Jwt)));

        builder.Services.AddAuthentication().AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new()
                    {
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                    };

                    opt.Events = new JwtBearerEvents()
                    {
                        OnTokenValidated = async (context) =>
                        {
                            string? email = context.Principal?.FindFirst(ClaimTypes.Email)?.Value;
                            IUserService userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                            if (string.IsNullOrWhiteSpace(email))
                            {
                                context.Fail("Invalid Token");
                                return;
                            }
                            User? user = await userService.FindByEmailAsync(email);
                            if (user == null)
                            {
                                context.Fail("Invalid user details");
                            }
                            context.HttpContext.Items["User"] = user;
                        }
                    };

                });
        return builder;
    }
}
