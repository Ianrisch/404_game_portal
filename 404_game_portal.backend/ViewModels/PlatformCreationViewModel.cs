using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class PlatformCreationViewModel
{
    public Guid Id  { get; set; }

    public List<Guid> Games { get; set; }
    public List<PriceOnPlatform> Prices { get; set; }
    public string PlatformName { get; set; }
    public string PlatformVersion { get; set; }
    public string PlatformType { get; set; }
}