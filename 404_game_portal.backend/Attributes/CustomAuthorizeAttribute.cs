using System.Security.Claims;
using _404_game_portal.backend.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace _404_game_portal.backend.Attributes;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAuthorizeAttribute(params Role[]? roles) : Attribute, IAuthorizationFilter
{
    private readonly IList<Role> _roles = roles ?? [];

    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        // skip authorization if action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        // authorization
        var roles = context.HttpContext.User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => (Role)Enum.Parse(typeof(Role), c.Value))
            .ToList();

        var isUnauthenticated =
            !(await context.HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme)).Succeeded;

        if (isUnauthenticated || (_roles.Any() && !roles.Any(r => _roles.Contains(r))))
        {
            context.Result = new JsonResult(new { message = "Unauthorized" })
                { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}