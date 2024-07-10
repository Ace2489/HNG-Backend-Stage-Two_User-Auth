namespace HNG_Backend_Stage_Two_User_Auth.Filters;
using HNG_Backend_Stage_Two_User_Auth.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

public sealed class CustomValidationFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            throw new InvalidJSONException(context.ModelState);
        }
    }

}
