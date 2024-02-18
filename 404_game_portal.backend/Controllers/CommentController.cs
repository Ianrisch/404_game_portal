using _404_game_portal.backend.Attributes;
using _404_game_portal.backend.Dto;
using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Enums;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[CustomAuthorize(Role.User, Role.Admin)]
public class CommentController(IGameCommentRepository gameCommentRepository, IUserRepository userRepository)
    : ControllerBase
{
    [HttpPost]
    public async Task<CommentViewModel> Create(CommentCreationViewModel creationViewModel)
    {
        var dto = new CommentCreationDto(creationViewModel)
        {
            UserId = (await userRepository.GetByMailOrUsername(User.Identity!.Name!))!.Id,
        };
        return new CommentViewModel(gameCommentRepository.Create(dto));
    }

    [HttpPut]
    public async Task<CommentViewModel> Update(CommentUpdateViewModel updateViewModel)
    {
        var dto = new CommentUpdateDto(updateViewModel)
        {
            UserId = (await userRepository.GetByMailOrUsername(User.Identity!.Name!))!.Id,
        };
        return new CommentViewModel(gameCommentRepository.Update(dto));
    }

    [HttpGet("{gameId:guid}")]
    public List<GameComment> GetByGameId(Guid gameId)
    {
        return gameCommentRepository.GetByGameId(gameId);
    }
}