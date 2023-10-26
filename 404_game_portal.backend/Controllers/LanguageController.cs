using _404_game_portal.backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;
[ApiController]
[Route("[controller]")]
public class LanguageController : ControllerBase
{
    private readonly ILanguageRepository _languageRepository;

    public LanguageController(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }
}