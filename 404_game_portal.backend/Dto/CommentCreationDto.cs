using _404_game_portal.backend.Entities;
using _404_game_portal.backend.ViewModels;

namespace _404_game_portal.backend.Dto;

public class CommentCreationDto
{
    public CommentCreationDto(CommentCreationViewModel creationViewModel)
    {
        Comment = creationViewModel.Comment;
        GameId = creationViewModel.GameId;
    }
    
    public Guid UserId { get; set; }
    public Guid GameId { get; set; }
    public string Comment { get; set; }
}