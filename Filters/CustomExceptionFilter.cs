using HNG_Backend_Stage_Two_User_Auth.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HNG_Backend_Stage_Two_User_Auth.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is InvalidJSONException validationException)
        {
            context.Result = new ObjectResult(new { errors = validationException.Errors})
            {
                StatusCode = StatusCodes.Status422UnprocessableEntity
            };
            context.ExceptionHandled = true;
        }
    }
}
