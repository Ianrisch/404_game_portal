using System.Security.Claims;
using _404_game_portal.backend.Services;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;

[Controller]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Login([FromBody] LoginViewModel loginViewModel)
    {
        if (!await authService.Authenticate(loginViewModel))
        {
            return BadRequest();
        }

        var user = await authService.GetUser(loginViewModel.EmailOrUsername);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties { IsPersistent = true}
        );

        return Ok();
    }

    [HttpGet("logout")]
    public async Task<ActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok();
    }

    [HttpGet("user")]
    [Authorize]
    public async Task<ActionResult<UserViewModel>> GetUser([FromQuery] string usernameOrEmail)
    {
        return Ok(await authService.GetUser(usernameOrEmail));
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] UserCreationViewModel userViewModel)
    {
        await authService.Register(userViewModel);
        return Ok();
    }
}