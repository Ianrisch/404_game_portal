using _404_game_portal.backend.ViewModels;

namespace _404_game_portal.backend.Entities;

public class Platform
{
    public Guid Id { get; set; }

    public List<GamePlatform> GamePlatforms { get; set; }
    public string PlatformName { get; set; }
    public string PlatformVersion { get; set; }
    public string PlatformType { get; set; }

    public Platform(PlatformAndPriceViewModel creationAndPriceViewModel)
    {
        if (creationAndPriceViewModel.Id is not null)
            Id = (Guid)creationAndPriceViewModel.Id;

        PlatformName = creationAndPriceViewModel.PlatformName;
        PlatformVersion = creationAndPriceViewModel.PlatformVersion;
        PlatformType = creationAndPriceViewModel.PlatformType;
    }

    public Platform()
    {
    }
}