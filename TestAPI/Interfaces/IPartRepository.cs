using TestAPI.Models;

namespace TestAPI.Interfaces;

public interface IPartRepository
{
    public Task<List<Part>> GetPartsAsync();
    public Task<Part> GetPartByIdAsync(int partId);
    public Task<bool> CreatePartAsync(Part part);
    public Task<bool> IsPartExistAsync(int partId);
    public Task<Kit> UpdateKitAsync(int partId);
    public Task<Kit> DeleteKitAsync(int partId);
}
