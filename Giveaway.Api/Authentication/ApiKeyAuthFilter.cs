using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Giveaway.Api.Authentication
{
    public class ApiKeyAuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("Ingrese API Key");
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            var apiKey = configuration!.GetValue<string>(AuthConstants.ApiKeySectionName);

            if (!apiKey!.Equals(extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("API Key inválido");
                return;
            }
        }
    }
}
