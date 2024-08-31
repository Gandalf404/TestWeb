using Microsoft.EntityFrameworkCore;
using TestAPI.Interfaces;
using TestAPI.Models;

namespace TestAPI.Repositories;

public class KitRepository(InvoicesContext invoicesContext) : IKitRepository
{
    private readonly InvoicesContext _invoicesContext = invoicesContext;

    public async Task<List<Kit>> GetKitsAsync()
    {
        return await _invoicesContext.Kits.ToListAsync();
    }

    public async Task<Kit> GetKitByIdAsync(int kitId)
    {
        return await _invoicesContext.Kits.FirstOrDefaultAsync(c => c.KitId == kitId);
    }

    public async Task<bool> PostKitAsync(Kit kit)
    {
        await _invoicesContext.Kits.AddAsync(kit);
        await _invoicesContext.SaveChangesAsync();
        return true;
    }
}
