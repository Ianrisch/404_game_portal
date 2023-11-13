using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguageController : ControllerBase
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IGameRepository _gameRepository;

    public LanguageController(ILanguageRepository languageRepository, IGameRepository gameRepository)
    {
        _languageRepository = languageRepository;
        _gameRepository = gameRepository;
    }

    [HttpGet]
    public List<Language> GetAll()
    {
        return _languageRepository.GetAll();
    }

    [HttpGet("{id:guid}")]
    public Language GetById(Guid id)
    {
        return _languageRepository.GetById(id);
    }

    [HttpPost]
    public Language Create(LanguageCreationViewModel creationViewModel)
    {
        var language = new Language();
        if (creationViewModel.Games is not null)
            language.Games = _gameRepository.GetByIds(creationViewModel.Games);
        language.LanguageName = creationViewModel.LanguageName;
        return _languageRepository.Create(language);
    }
}