using HNG_Backend_Stage_Two_User_Auth.Models;

namespace HNG_Backend_Stage_Two_User_Auth.Extensions;

public static class HttpRequestExtensions
{
    public static User? GetAuthUser(this HttpContext context)
    {
        return (User?) context.Items["User"];
    }
}
