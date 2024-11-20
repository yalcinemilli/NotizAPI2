using NotizAPI2.Models;

namespace NotizAPI2.Services;

// Schnittstelle für die Geschäftslogik der Notizen.
    public interface INotizService
    {
   Task<IEnumerable<Notiz>> GetAllAsync();
    Task<Notiz?> GetByIdAsync(int id);
    Task<Notiz> CreateAsync(Notiz notiz);
    Task UpdateAsync(Notiz notiz);
    Task DeleteAsync(int id);

    }
