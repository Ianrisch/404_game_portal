namespace _404_game_portal.backend.Entities;

public class Feature
{
    public Guid Id  { get; set; }
    public List<Game> Games { get; set; }

    public string FeatureName { get; set; }
    public string FeatureDescription { get; set; }
}