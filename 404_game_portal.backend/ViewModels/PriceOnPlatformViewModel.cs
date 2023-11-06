using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class PriceOnPlatformViewModel
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public Game Game { get; set; }
    public Platform Platform { get; set; }

    public PriceOnPlatformViewModel(PriceOnPlatform priceOnPlatform)
    {
        Id = priceOnPlatform.Id;
        Price = priceOnPlatform.Price;
        Game = priceOnPlatform.Game;
        Platform = priceOnPlatform.Platform;
    }

    public PriceOnPlatformViewModel()
    {

    }
}