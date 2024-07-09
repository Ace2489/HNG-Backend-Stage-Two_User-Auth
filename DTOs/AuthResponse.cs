namespace HNG_Backend_Stage_Two_User_Auth.DTO;

public record AuthResponse
{
    public required string accessToken { get; set; }

    public required AuthUser user { get; set; }
}

public record AuthUser
{
    public required string userId { get; set; }

    public required string firstName { get; set; }

    public required string lastName { get; set; }

    public required string email { get; set; }

    public required string phone { get; set; }

}

