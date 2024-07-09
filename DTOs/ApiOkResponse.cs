namespace HNG_Backend_Stage_Two_User_Auth.DTO;

public record ApiOkResponse<T>
{
    public string status { get; set; } = "success";

    public required string message { get; set; }

    public T? data { get; set; }
}


