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

    public LanguageController(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
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
        return _languageRepository.Create(creationViewModel);
    }
}