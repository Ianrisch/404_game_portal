using _404_game_portal.backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IUserRepository
{
    public Task Register(string email, string username, string password);
    Task<User> GetByMailOrUsername(string emailOrUsername);
}

public class UserRepository(Context context) : IUserRepository
{
    public Task Register(string email, string username, string password)
    {
        context.Users.AddAsync(new User { Email = email, Username = username, Password = password });
        return context.SaveChangesAsync();
    }

    public Task<User> GetByMailOrUsername(string emailOrUsername)
    {
        return context.Users.SingleAsync(u => u.Email == emailOrUsername || u.Username == emailOrUsername);
    }
}