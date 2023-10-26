using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class FeatureCreationViewModel
{
    public List<Guid> Games { get; set; }
    
    public string FeatureName { get; set; }
    public string FeatureDescription { get; set; }
}