using TestAPI.Models;

namespace TestAPI.Interfaces;

public interface IKitRepository
{
    public Task<List<Kit>> GetKitsAsync();
    public Task<Kit> GetKitByIdAsync(int kitId);
    public Task<bool> PostKitAsync(Kit kit);
}
