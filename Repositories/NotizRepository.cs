using Microsoft.EntityFrameworkCore;
using NotizAPI2.Data;
using NotizAPI2.Models;

namespace NotizAPI2.Repositories;

// Repository für Datenzugriff auf die Notizen.
    public class NotizRepository : INotizRepository
{

    private readonly NotizenContext _context;
    
    // Initialisiert ein neues NotizRepository mit dem gegebenen Datenbankkontext.
    
    public NotizRepository(NotizenContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Notiz>> GetAllAsync()
    {
        // Abrufen aller Notizen aus der Datenbank
        return await _context.notizen.ToListAsync();
    }

    public async Task<Notiz?> GetByIdAsync(int id)
    {
        // Abrufen einer Notiz anhand ihrer ID
        return await _context.notizen.FindAsync(id);
    }

    public async Task<Notiz> CreateAsync(Notiz notiz)
    {
        // Hinzufügen einer neuen Notiz zur Datenbank
        await _context.notizen.AddAsync(notiz);
        await _context.SaveChangesAsync();
        return notiz;
    }

    public async Task UpdateAsync(Notiz notiz)
    {
        // Aktualisieren der Notiz in der Datenbank
        _context.Entry(notiz).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        // Löschen einer Notiz basierend auf der ID
        var notiz = await _context.notizen.FindAsync(id);
        if (notiz != null)
        {
            _context.notizen.Remove(notiz);
            await _context.SaveChangesAsync();
        }
    }
    
}
