using TestAPI.Models;

namespace TestAPI.Interfaces;

public interface IKitRepository
{
    public Task<List<Kit>> GetKitsAsync();
    public Task<Kit> GetKitByIdAsync(int kitId);
    public Task<bool> CreateKitAsync(Kit kit);
    public Task<bool> IsKitExistAsync(int kitId);
    public Task<Kit> UpdateKitAsync(int kitId);
    public Task<Kit> DeleteKitAsync(int kitId);
}
