using _404_game_portal.backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface ILanguageRepository
{
    public Language GetById(Guid id);
    public Language Create(Language language);
    public List<Language> GetAll();
}

public class LanguageRepository : ILanguageRepository
{
    private readonly Context _context;

    public LanguageRepository(Context context)
    {
        _context = context;
    }

    public Language GetById(Guid id)
    {
        return _context.Languages
            .Include(e => e.Games)
            .SingleOrDefault(e => e.Id == id) ?? new Language();
    }

    public Language Create(Language language)
    {
        _context.Languages.Add(language);
        _context.SaveChanges();
        return language;
    }

    public List<Language> GetAll()
    {
        return _context.Languages.Include(e => e.Games).ToList();
    }
}