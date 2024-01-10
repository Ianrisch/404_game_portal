using _404_game_portal.backend.ViewModels;

namespace _404_game_portal.backend.Entities;

public class Feature
{
    public Guid Id { get; set; }
    public List<GameFeature> GameFeatures { get; set; }

    public string FeatureName { get; set; }
    public string FeatureDescription { get; set; }

    public Feature(FeatureViewModel featureViewModel)
    {
        Id = featureViewModel.Id;

        FeatureName = featureViewModel.FeatureName;
        FeatureDescription = featureViewModel.FeatureDescription;
    }

    public Feature()
    {
    }
}