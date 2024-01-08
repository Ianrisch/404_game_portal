namespace _404_game_portal.backend.Entities;

public class GameFeature
{
    public Game Game { get; set; }
    public Guid GameId { get; set; }
    public Feature Feature { get; set; }
    public Guid FeatureId { get; set; }
}