using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class GameCreationViewModel
{
    public string Name { get; set; }
    public List<Guid> Platforms { get; set; }
    public Usk USK { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Description { get; set; }
    public List<Guid>? Features { get; set; }
    public List<Guid> Languages { get; set; }
}