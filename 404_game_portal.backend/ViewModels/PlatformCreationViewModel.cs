namespace _404_game_portal.backend.ViewModels;

public class PlatformCreationViewModel
{
    public List<PlatformCreationPriceAndGameViewModel> GamesAndPrices { get; set; }
    public string PlatformName { get; set; }
    public string PlatformVersion { get; set; }
    public string PlatformType { get; set; }
}