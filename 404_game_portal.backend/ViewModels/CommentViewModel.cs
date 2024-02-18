using _404_game_portal.backend.Dto;
using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class CommentViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public Guid GameId { get; set; }
    public string Comment { get; set; }

    public CommentViewModel(GameCommentDto gameCommentDto)
    {
        Id = gameCommentDto.Id;
        UserId = gameCommentDto.UserDto.Id;
        UserName = gameCommentDto.UserDto.Username;
        GameId = gameCommentDto.GameId;
        Comment = gameCommentDto.Comment;
    }

}