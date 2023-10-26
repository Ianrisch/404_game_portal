using _404_game_portal.backend.ViewModels;

namespace _404_game_portal.backend.Entities;

public class PriceOnPlatform
{
    public PriceOnPlatform(PriceOnPlatformCreationViewModel creationViewModel)
    {
        Price = creationViewModel.Price;
        Game = creationViewModel.Game;
        Platform = creationViewModel.Platform;
    }

    public PriceOnPlatform()
    {
    }

    public Guid Id { get; set; }

    public int Price { get; set; }
    public Game Game { get; set; }
    public Guid PlatformId { get; set; }
    public Platform Platform { get; set; }
}