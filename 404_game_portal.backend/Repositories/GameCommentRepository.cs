using _404_game_portal.backend.Dto;
using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Extensions;
using _404_game_portal.backend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IGameCommentRepository
{
    GameCommentDto GetById(Guid id);
    List<GameCommentDto> GetByGameId(Guid id);
    GameCommentDto Create(CommentCreationDto creationDto);
    GameCommentDto Update(CommentUpdateDto updateDto);
}

public class GameCommentRepository : IGameCommentRepository
{
    private readonly Context _context;

    public GameCommentRepository(Context context)
    {
        _context = context;
    }

    public GameCommentDto GetById(Guid id)
    {
        return _context.GameComments
            .Include(gc => gc.User)
            .ToDto()
            .SingleOrDefault(gc => gc.Id == id) ?? new GameCommentDto();
    }

    public List<GameCommentDto> GetByGameId(Guid gameId)
    {
        return _context.GameComments
            .Include(gc => gc.User)
            .Where(gc => gc.GameId == gameId)
            .ToDto()
            .ToList();
    }

    public GameCommentDto Create(CommentCreationDto creationDto)
    {
        var gameComment = new GameComment
        {
            UserId = creationDto.UserId,
            GameId = creationDto.GameId,
            Comment = creationDto.Comment
        };
        _context.GameComments.Add(gameComment);
        _context.SaveChanges();
        return GetById(gameComment.Id);
    }

    public GameCommentDto Update(CommentUpdateDto updateDto)
    {
        var gameComment = _context.GameComments
            .SingleOrDefault(gc => gc.Id == updateDto.Id && gc.UserId == updateDto.UserId);

        gameComment.Comment = updateDto.Comment;
        _context.SaveChanges();
        return GetById(gameComment.Id);
    }
}