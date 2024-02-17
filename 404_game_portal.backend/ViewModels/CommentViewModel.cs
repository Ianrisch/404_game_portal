using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class CommentViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid GameId { get; set; }
    public string Comment { get; set; }

    public CommentViewModel(GameComment gameComment)
    {
        Id = gameComment.Id;
        UserId = gameComment.UserId;
        GameId = gameComment.GameId;
        Comment = gameComment.Comment;
    }
}