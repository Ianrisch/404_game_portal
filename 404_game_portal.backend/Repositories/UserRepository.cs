namespace _404_game_portal.backend.Repositories;
public interface IUserRepository
{
    public Task Register(string email, string username, string password);
    public Task<bool> Authenticate(string emailOrUsername, string password);
}
public class UserRepository(Context context) : IUserRepository
{
    public Task Register(string email, string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Authenticate(string emailOrUsername, string password)
    {
        throw new NotImplementedException();
    }
}