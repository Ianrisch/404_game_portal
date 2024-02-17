using _404_game_portal.backend.Dto;
using _404_game_portal.backend.Entities;
using _404_game_portal.backend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IGameCommentRepository
{
    GameComment GetById(Guid id);
    GameComment Create(CommentCreationDto creationDto);
    GameComment Update(CommentUpdateDto updateDto);
}

public class GameCommentRepository : IGameCommentRepository
{
    private readonly Context _context;

    public GameCommentRepository(Context context)
    {
        _context = context;
    }

    public GameComment GetById(Guid id)
    {
        return _context.GameComments
            .Include(gc => gc.Id)
            .SingleOrDefault(gc => gc.Id == id) ?? new GameComment();
    }

    public GameComment Create(CommentCreationDto creationDto)
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

    public GameComment Update(CommentUpdateDto updateDto)
    {
        var gameComment = _context.GameComments.SingleOrDefault(gc =>
            gc.Id == updateDto.Id && gc.UserId == updateDto.UserId);
        
        gameComment.Comment = updateDto.Comment;
        _context.SaveChanges();
        return GetById(gameComment.Id);
    }
}