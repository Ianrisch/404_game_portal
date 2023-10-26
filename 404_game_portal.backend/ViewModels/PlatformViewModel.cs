using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class PlatformViewModel
{
    public Guid? Id  { get; set; }
    public string PlatformName { get; set; }
    public string PlatformVersion { get; set; }
    public string PlatformType { get; set; }

    public PlatformViewModel(Platform platform)
    {
        Id = platform.Id;
        PlatformName = platform.PlatformName;
        PlatformVersion = platform.PlatformVersion;
        PlatformType = platform.PlatformType;
    }

    public PlatformViewModel()
    {
    }
}