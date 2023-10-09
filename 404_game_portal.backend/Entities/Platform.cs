namespace _404_game_portal.backend.Entities;

public class Platform
{
    public Guid Id  { get; set; }

    public List<Game> Games { get; set; }
    public List<PriceOnPlatform> Prices { get; set; }
    public string PlatformName { get; set; }
    public string PlatformVersion { get; set; }
    public string PlatformType { get; set; }
}