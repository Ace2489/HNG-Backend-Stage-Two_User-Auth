using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using HNG_Backend_Stage_Two_User_Auth.Models;

namespace HNG_Backend_Stage_Two_User_Auth;

public sealed class Organisation
{
    [Key]
    [JsonInclude]
    [Required]
    public string? OrgId { get; set; }

    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }

    public List<UserOrganisation> UserOrganisations { get; set; } = null!; 
}
