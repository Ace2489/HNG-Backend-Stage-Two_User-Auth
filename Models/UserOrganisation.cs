using System.ComponentModel.DataAnnotations;
using HNG_Backend_Stage_Two_User_Auth.Models;

namespace HNG_Backend_Stage_Two_User_Auth;

public class UserOrganisation
{

    [Required]    
    public required string UserId { get; set; }

    [Required]
    public required string OrgId { get; set; }

    [Required]
    public User User { get; set; } = null!;

    [Required]
    public Organisation Organisation { get; set; } = null!;

    [Required]
    public DateTimeOffset CreationDate { get; set;}
}
