using CleanArchitecture.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.WebAPI.Filters;
public class ProducesResponseTypeFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Optional: Set the content type for the response
        Console.WriteLine("ProducesResponseTypeFilter OnActionExecuting");
        context.HttpContext.Response.ContentType = "application/json";
        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        // Check the result of the action
        //&& objectResult.Value is Result<context> result

        if (context.Result is ObjectResult objectResult)
        {
            var resultType = objectResult.Value?.GetType();
            if (resultType != null && resultType.IsGenericType && resultType.GetGenericTypeDefinition() == typeof(Result<>))
            {
                var errorCodeProperty = resultType.GetProperty("ErrorCode");
                if (errorCodeProperty != null)
                {
                    var errorCode = (int)errorCodeProperty.GetValue(objectResult.Value);
                    // Set the response type based on the status code
                    switch (errorCode)
                    {
                        case StatusCodes.Status200OK:
                            // Optionally customize the response if needed
                            break;
                        case StatusCodes.Status401Unauthorized:
                            // Handle unauthorized response
                            context.Result = new ObjectResult(new { error = "Unauthorized access" })
                            {
                                StatusCode = StatusCodes.Status401Unauthorized
                            };
                            break;
                        case StatusCodes.Status404NotFound:
                            // Handle not found response
                            context.Result = new ObjectResult(new { error = "Resource not found" })
                            {
                                StatusCode = StatusCodes.Status404NotFound
                            };
                            break;
                        case StatusCodes.Status500InternalServerError:
                            // Handle internal server error
                            context.Result = new ObjectResult(new { error = "Internal server error" })
                            {
                                StatusCode = StatusCodes.Status500InternalServerError
                            };
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        base.OnActionExecuted(context);
    }
}
