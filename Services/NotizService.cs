using NotizAPI2.Models;
using NotizAPI2.Repositories;

namespace NotizAPI2.Services;

// Implementierung der Geschäftslogik für Notizen.
    public class NotizService  : INotizService
{
    private readonly INotizRepository _repository;

// Initialisiert einen neuen NotizService mit dem gegebenen Repository.
    public NotizService(INotizRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Notiz>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Notiz?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task<Notiz> CreateAsync(Notiz notiz) => _repository.CreateAsync(notiz);

    public Task UpdateAsync(Notiz notiz) => _repository.UpdateAsync(notiz);

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}