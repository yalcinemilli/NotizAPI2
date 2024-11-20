using NotizAPI2.Models;

// Schnittstelle für Datenzugriff auf Notizen.
namespace NotizAPI2.Repositories;

public interface INotizRepository
{
    Task<IEnumerable<Notiz>> GetAllAsync();
    Task<Notiz?> GetByIdAsync(int id);
    Task<Notiz> CreateAsync(Notiz notiz);
    Task UpdateAsync(Notiz notiz);
    Task DeleteAsync(int id);
}