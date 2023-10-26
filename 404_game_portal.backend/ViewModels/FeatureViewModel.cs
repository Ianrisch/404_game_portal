﻿namespace _404_game_portal.backend.ViewModels;

public class FeatureViewModel
{
    public Guid Id { get; set; }
    
    public List<GameViewModel> Games { get; set; }
    
    public string FeatureName { get; set; }
    public string FeatureDescription { get; set; }
}