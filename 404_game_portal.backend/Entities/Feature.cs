using _404_game_portal.backend.ViewModels;

namespace _404_game_portal.backend.Entities;

public class Feature
{
    public Guid Id  { get; set; }
    public List<Game> Games { get; set; }

    public string FeatureName { get; set; }
    public string FeatureDescription { get; set; }

    public Feature(FeatureViewModel featureViewModel)
    {
        if (featureViewModel.Id is not null)
            Id = (Guid)featureViewModel.Id;

        FeatureName = featureViewModel.FeatureName;
        FeatureDescription = featureViewModel.FeatureDescription;
    }

    public Feature()
    {
    }
}