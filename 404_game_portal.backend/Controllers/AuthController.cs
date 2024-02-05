using System.Security.Claims;
using _404_game_portal.backend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;

[Controller]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Login([FromBody] string username, [FromBody] string password)
    {
        if (!await authService.Authenticate(username, password))
        {
            return BadRequest();
        }

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) })),
            new AuthenticationProperties { IsPersistent = true }
        );

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] string email, [FromBody] string username, [FromBody] string password)
    {
        await authService.Register(email, username, password);
        return Ok();
    }
}