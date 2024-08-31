using Microsoft.EntityFrameworkCore;
using TestAPI.Interfaces;
using TestAPI.Models;

namespace TestAPI.Repositories;

public class PartRepository(InvoicesContext invoicesContext) : IPartRepository
{
    private readonly InvoicesContext _invoicesContext = invoicesContext;

    public async Task<List<Part>> GetPartsAsync()
    {
        return await _invoicesContext.Parts.ToListAsync();
    }

    public async Task<Part> GetPartByIdAsync(int partId)
    {
        return await _invoicesContext.Parts.FirstOrDefaultAsync(c => c.PartId == partId);
    }

    public async Task<bool> PostPartAsync(Part part)
    {
        await _invoicesContext.Parts.AddAsync(part);
        await _invoicesContext.SaveChangesAsync();
        return true;
    }
}
