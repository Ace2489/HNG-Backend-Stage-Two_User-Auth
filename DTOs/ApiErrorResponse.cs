namespace HNG_Backend_Stage_Two_User_Auth.DTO;

public record Api401Response
{
    public string status { get; set; } = "Bad Request";

    public required string message { get; set; }


}


