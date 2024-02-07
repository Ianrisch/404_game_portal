using System.Security.Claims;
using _404_game_portal.backend.Attributes;
using _404_game_portal.backend.Services;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;

[Controller]
[CustomAuthorize]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
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
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties { IsPersistent = true }
        );

        return Ok();
    }
    [HttpGet("isLoggedIn")]
    public ActionResult IsLoggedIn()
    {
        return Ok(User.Identity?.IsAuthenticated);
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult> Register([FromBody] UserCreationViewModel userViewModel)
    {
        await authService.Register(userViewModel);
        return Ok();
    }

    [HttpGet("logout")]
    public async Task<ActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok();
    }

    [HttpGet("user")]
    public async Task<ActionResult<UserViewModel>> GetUser([FromQuery] string? usernameOrEmail)
    {
        if (usernameOrEmail != null) return Ok(await authService.GetUser(usernameOrEmail));

        if (User.Identity?.Name != null)
        {
            return Ok(await authService.GetUser(User.Identity.Name));
        }

        return NotFound();
    }

    [HttpPut("changePassword")]
    public async Task<ActionResult> ChangePassword([FromBody] UserChangePasswordViewModel userChangePasswordViewModel)
    {
        if (User.Identity?.Name == null) return Forbid();

        try
        {
            await authService.ChangePassword(userChangePasswordViewModel, User.Identity.Name);

            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}