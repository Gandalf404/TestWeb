using TestAPI.Models;

namespace TestAPI.Interfaces;

public interface IPartRepository
{
    public Task<List<Part>> GetPartsAsync();
    public Task<Part> GetPartByIdAsync(int partId);
    public Task<bool> PostPartAsync(Part part);
}
