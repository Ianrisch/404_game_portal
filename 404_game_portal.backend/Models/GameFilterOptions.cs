using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.Models;

public class GameFilterOptions
{
    public string? GameName { get; set; }
    public int? MaximumPrice { get; set; }
    public Guid? PlatformId { get; set; }
    public Guid? FeatureId { get; set; }
    public Guid? LanguageId { get; set; }
    public Usk? Usk { get; set; }
    public double? MinRating { get; set; }
}