using HNG_Backend_Stage_Two_User_Auth.DTO;
using HNG_Backend_Stage_Two_User_Auth.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace HNG_Backend_Stage_Two_User_Auth.Controllers;

[Route("/auth")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService authService = authService;

    [HttpGet]
    public ActionResult Get()
    {
        return Ok();
    }

    [HttpPost("register")]

    public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest registerRequest, CancellationToken cancellationToken = default)
    {

        AuthResponse? response = await authService.RegisterAsync(registerRequest, cancellationToken);
        if(response != null)
        {
            return this.OkWithData(response, "Registration successful");
        }
        return  BadRequest(new
        {
            status = "Bad request",
            message = "Registration unsuccessful",
            statusCode = 400
        });
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken = default)
    {
        AuthResponse? response = await authService.LoginAsync(loginRequest, cancellationToken);
        if (response == null)
        {
            return this.Api401Error("Authentication failure");
        }
        return this.OkWithData(response, "Login successful");
    }
}
