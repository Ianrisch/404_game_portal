using System.Security.Cryptography;
using _404_game_portal.backend.Repositories;

namespace _404_game_portal.backend.Services;

public interface IAuthService
{
    public Task<bool> Authenticate(string emailOrUsername, string password);
    public Task Register(string email, string username, string password);
}

public class AuthService(IUserRepository userRepository) : IAuthService
{
    public async Task<bool> Authenticate(string emailOrUsername, string password)
    {
        var user = await userRepository.GetByMailOrUsername(emailOrUsername);
        return PasswordHasher.Verify(password, user.Password);
    }

    public Task Register(string email, string username, string password)
    {
        return userRepository.Register(email, username, PasswordHasher.Hash(password));
    }
}