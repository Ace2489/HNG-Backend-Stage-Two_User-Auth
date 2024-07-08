using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HNG_Backend_Stage_Two_User_Auth.Models;

public class User
{
    [JsonIgnore]
    [Required]
    [MaxLength(255)]
    public string? UserId { get; set; }
    
    [Required]
    public required string FirstName { get; set; }
    
    [Required]
    public required string LastName { get; set; }

    [Required]
    [MaxLength(255)]
    public required string Email { get; set; }
    
    [Required]
    public string? Password { get; set; }
    
    [Required]
    public required string Phone { get; set; }
}
