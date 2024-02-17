using _404_game_portal.backend.ViewModels;

namespace _404_game_portal.backend.Dto;

public class CommentUpdateDto
{
    public CommentUpdateDto(CommentUpdateViewModel updateViewModel)
    {
        Comment = updateViewModel.Comment;
        Id = updateViewModel.Id;
    }
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Comment { get; set; }
}