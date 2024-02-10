using _404_game_portal.backend.Entities;
using _404_game_portal.backend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IUserRepository
{
    public Task Register(string email, string username, string password);
    Task<User?> GetByMailOrUsername(string emailOrUsername);
    Task<UserViewModel> ChangePassword(string username, string hash);
}

public class UserRepository(Context context) : IUserRepository
{
    public Task Register(string email, string username, string password)
    {
        context.Users.AddAsync(new User { Email = email, Username = username, Password = password });
        return context.SaveChangesAsync();
    }

    public Task<User?> GetByMailOrUsername(string emailOrUsername)
    {
        return context.Users.SingleOrDefaultAsync(u => u.Email == emailOrUsername || u.Username == emailOrUsername);
    }

    public async Task<UserViewModel> ChangePassword(string username, string hash)
    {
        var user = await context.Users.Where(u => u.Username == username).SingleAsync();
        user.Password = hash;
        await context.SaveChangesAsync();
        return new UserViewModel(user);
    }
}