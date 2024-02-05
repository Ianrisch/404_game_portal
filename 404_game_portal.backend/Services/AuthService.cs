using System.Security.Cryptography;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.ViewModels;

namespace _404_game_portal.backend.Services;

public interface IAuthService
{
    public Task<bool> Authenticate(LoginViewModel loginViewModel);
    public Task Register(UserCreationViewModel userViewModel);
    Task<UserViewModel> GetUser(string usernameOrEmail);
    public Task<UserViewModel> ChangePassword(UserChangePasswordViewModel userChangePasswordViewModel, string username);
}

public class AuthService(IUserRepository userRepository) : IAuthService
{
    public async Task<bool> Authenticate(LoginViewModel loginViewModel)
    {
        var user = await userRepository.GetByMailOrUsername(loginViewModel.EmailOrUsername);
        return PasswordHasher.Verify(loginViewModel.Password, user.Password);
    }

    public Task Register(UserCreationViewModel userViewModel)
    {
        return userRepository.Register(userViewModel.Email, userViewModel.Username,
            PasswordHasher.Hash(userViewModel.Password));
    }

    public async Task<UserViewModel> GetUser(string usernameOrEmail)
    {
        return new UserViewModel(await userRepository.GetByMailOrUsername(usernameOrEmail));
    }

    public async Task<UserViewModel> ChangePassword(UserChangePasswordViewModel changePassword, string username)
    {
        if (!await Authenticate(new LoginViewModel()
                { Password = changePassword.OldPassword, EmailOrUsername = username }))
            throw new UnauthorizedAccessException();

        return await userRepository.ChangePassword(username, PasswordHasher.Hash(changePassword.NewPassword));
    }
}