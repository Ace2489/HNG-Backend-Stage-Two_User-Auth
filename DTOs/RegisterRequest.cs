using System.ComponentModel.DataAnnotations;

namespace HNG_Backend_Stage_Two_User_Auth;

public class RegisterRequest
{

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Phone { get; set; }
}

