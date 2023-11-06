namespace _404_game_portal.backend.Entities;

public class PriceOnPlatform
{
    public Guid Id { get; set; }

    public double Price { get; set; }
    public Game Game { get; set; }
    public Guid PlatformId { get; set; }
    public Platform Platform { get; set; }
}