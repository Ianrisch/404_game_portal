using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Enums;

namespace _404_game_portal.backend.ViewModels;

public class UserViewModel
{
    public UserViewModel(User getByMailOrUsername)
    {
        Email = getByMailOrUsername.Email;
        Username = getByMailOrUsername.Username;
        Role = getByMailOrUsername.Role;
    }

    public string Email { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; }
}