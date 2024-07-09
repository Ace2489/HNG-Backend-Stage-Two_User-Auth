using System.ComponentModel.DataAnnotations;

namespace HNG_Backend_Stage_Two_User_Auth.DTO;

public record RegisterRequest
{

    [Required]
    public string? firstName { get; set; }

    [Required]
    public string? lastName { get; set; }

    [EmailAddress]
    [Required]
    public string? email { get; set; }

    [Required]
    public string? password { get; set; }

    [Required]
    public string? phone { get; set; }
}

