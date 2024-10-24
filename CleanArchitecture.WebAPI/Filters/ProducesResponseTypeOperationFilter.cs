using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CleanArchitecture.WebAPI.Filters
{
    public class ProducesResponseTypeOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var customAttribute = context.MethodInfo
            .GetCustomAttributes(true)
            .OfType<ProducesResponseTypeAttribute>()
            .ToList();

            foreach (var attr in customAttribute)
            {
                operation.Responses.Add(attr.StatusCode.ToString(), new OpenApiResponse { Description = attr.Type?.Name });
            }
        }
    }
}
