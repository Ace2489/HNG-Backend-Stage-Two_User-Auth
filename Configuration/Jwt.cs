using System.ComponentModel.DataAnnotations;

namespace HNG_Backend_Stage_Two_User_Auth.Configuration;

public record Jwt
{
    public Jwt() { }

    public Jwt(string secret)
    {
        Secret = secret;
    }

    [Required]
    public string Issuer { get; set; } = null!;

    [Required]
    public string Audience { get; set; } = null!;

    [Required]
    public string Secret { get; set; } = null!;
    
}
