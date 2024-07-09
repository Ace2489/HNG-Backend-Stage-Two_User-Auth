using HNG_Backend_Stage_Two_User_Auth.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HNG_Backend_Stage_Two_User_Auth.Extensions;

public static class ControllerOKExtension
{
    public static ActionResult OkWithData<T>(this ControllerBase controller, T data, string message)
    {
        ApiOkResponse<T> successResponse = new() { data = data, message = message };
        return controller.Ok(successResponse);
    }
    public static ActionResult OkWithoutData<T>(this ControllerBase controller, string message)
    {
        ApiOkResponse<T> successResponse = new() { message = message };
        return controller.Ok(successResponse);
    }

    public static ActionResult Api401Error(this ControllerBase controller, string message)
    {
        Api401Response errorResponse = new() { message = message };
        return controller.BadRequest(errorResponse);
    }
}