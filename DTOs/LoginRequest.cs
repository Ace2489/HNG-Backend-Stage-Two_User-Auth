using System.ComponentModel.DataAnnotations;

namespace HNG_Backend_Stage_Two_User_Auth.DTO;

public record LoginRequest
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}
