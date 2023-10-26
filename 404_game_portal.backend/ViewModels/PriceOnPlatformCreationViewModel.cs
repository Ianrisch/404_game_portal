using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class PriceOnPlatformCreationViewModel
{
    public int Price { get; set; }
    public Game Game { get; set; }
    public Platform Platform { get; set; }
}