namespace _404_game_portal.backend.Dto;

public class GameCommentDto
{
    public Guid Id { get; set; }
    public Guid GameId { get; set; }
    public string Comment { get; set; }
    public GameCommentUserDto UserDto { get; set; }
}