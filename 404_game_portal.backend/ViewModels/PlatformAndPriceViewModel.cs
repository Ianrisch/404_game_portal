using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class PlatformAndPriceViewModel
{
    public Guid? Id { get; set; }
    public string PlatformName { get; set; }
    public string PlatformVersion { get; set; }
    public string PlatformType { get; set; }

    public double Price { get; set; }

    public PlatformAndPriceViewModel(GamePlatform gamePlatform)
    {
        Id = gamePlatform.Platform.Id;
        PlatformName = gamePlatform.Platform.PlatformName;
        PlatformVersion = gamePlatform.Platform.PlatformVersion;
        PlatformType = gamePlatform.Platform.PlatformType;
        Price = gamePlatform.Price;
    }

    public PlatformAndPriceViewModel()
    {
    }
}