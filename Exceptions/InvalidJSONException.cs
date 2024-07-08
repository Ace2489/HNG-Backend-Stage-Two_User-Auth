using System.Text;
using HNG_Backend_Stage_Two_User_Auth.Errors;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HNG_Backend_Stage_Two_User_Auth.Exceptions;

public class InvalidJSONException : Exception
{
    public IEnumerable<ValidationError> Errors { get; set; }
    public InvalidJSONException(ModelStateDictionary keyValues)
    {
        Errors = keyValues.Select((e) => new ValidationError()
        {
            Field = e.Key,
            Message = e.Value!.Errors.First().ErrorMessage
        });
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(GetType().Name + ": " + Message);

        if (Errors != null && Errors.Any())
        {
            sb.AppendLine("Validation Errors:");
            foreach (var error in Errors)
            {
                sb.AppendLine($"  Field: {error.Field}, Message: {error.Message}");
            }
        }

        if (StackTrace != null)
        {
            sb.AppendLine("Stack Trace:");
            sb.AppendLine(StackTrace);
        }

        return sb.ToString();
    }

}


