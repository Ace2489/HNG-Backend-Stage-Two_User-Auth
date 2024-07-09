using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoWrapper.Wrappers;
using HNG_Backend_Stage_Two_User_Auth.Configuration;
using HNG_Backend_Stage_Two_User_Auth.DTO;
using HNG_Backend_Stage_Two_User_Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace HNG_Backend_Stage_Two_User_Auth;

public interface IAuthService
{
    public Task<AuthResponse?> RegisterAsync(RegisterRequest registerRequest, CancellationToken cancellationToken = default);

    public Task<AuthResponse?> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken = default);
}

public class AuthService(
    IUserService userService,
    IOrganisationService organisationService,
    IPasswordHasher<User> passwordHasher,
    IUnitOfWork unitOfWork,
    IUserOrganisationService userOrganisationService,
    IOptions<Jwt> jwtOptions
    ) : IAuthService
{
    private readonly IUserService userService = userService;
    private readonly IOrganisationService organisationService = organisationService;
    private readonly IPasswordHasher<User> passwordHasher = passwordHasher;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IUserOrganisationService userOrganisationService = userOrganisationService;
    private readonly IOptions<Jwt> jwtOptions = jwtOptions;

    public async Task<AuthResponse?> RegisterAsync(RegisterRequest registerRequest, CancellationToken cancellationToken = default)
    {
        if (await userService.DoesUserExist(registerRequest.email!, cancellationToken: cancellationToken))
        {
            return null;
        }

        User createdUser = await CreateUserAsync(registerRequest, cancellationToken);

        Organisation createdOrganisation = await CreateOrganisationAsync(registerRequest.firstName, cancellationToken);


        await unitOfWork.SaveChangesAsync(cancellationToken);

        await userOrganisationService.AddUserToOrganisationAsync(createdUser.UserId, createdOrganisation.OrgId, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        LoginRequest request = new() { Email = registerRequest.email, Password = registerRequest.password };
        
        AuthResponse? response = await LoginAsync(request, cancellationToken);
        
        return response;
    }

    public async Task<AuthResponse?> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken = default)
    {
        User? user = await userService.FindByEmailAsync(loginRequest.Email, cancellationToken);

        if (user == null)
        {
            return null;
        }

        PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(user, user.Password, loginRequest.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return null;
        }

        AuthUser authUser = new()
        {
            userId = user.UserId,
            firstName = user.FirstName,
            lastName = user.LastName,
            email = user.Email,
            phone = user.Phone
        };
        return new AuthResponse() { accessToken = GenerateJwtToken(loginRequest.Email), user = authUser };
    }
    private async Task<User> CreateUserAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        User user = new()
        {
            FirstName = request.firstName,
            LastName = request.lastName,
            Email = request.email,
            Phone = request.phone
        };

        user.Password = passwordHasher.HashPassword(user, request.password);

        user = await userService.AddAsync(user, cancellationToken);

        return user;
    }

    private async Task<Organisation> CreateOrganisationAsync(string Name, CancellationToken cancellationToken)
    {
        string orgName = Name.EndsWith('s') ? $"{Name}'" : $"{Name}'s";
        orgName += " Organisation";
        Organisation org = new() { Name = orgName };
        org = await organisationService.AddAsync(org, cancellationToken);
        return org;
    }

    private string GenerateJwtToken(string email)
    {
        JwtSecurityTokenHandler tokenHandler = new();
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity([new Claim(ClaimTypes.Email, email)]),
            Expires = DateTime.UtcNow.AddMinutes(15),
            Issuer = jwtOptions.Value.Issuer,
            Audience = jwtOptions.Value.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Value.Secret)),
                SecurityAlgorithms.HmacSha512Signature),
            
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
