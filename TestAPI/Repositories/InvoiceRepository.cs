using Microsoft.EntityFrameworkCore;
using TestAPI.Interfaces;
using TestAPI.Models;

namespace TestAPI.Repositories;

public class InvoiceRepository(InvoicesContext invoicesContext) : IInvoiceRepository
{
    private readonly InvoicesContext _invoicesContext = invoicesContext;

    public async Task<List<Invoice>> GetInvoicesAsync()
    {
        return await _invoicesContext.Invoices.Include(c => c.Kit).Include(c => c.Part).ToListAsync();
    }

    public async Task<Invoice> GetInvoiceByIdAsync(int id)
    {
        return await _invoicesContext.Invoices.FirstOrDefaultAsync(c => c.InvoiceId == id);
    }

    public async Task<bool> PostInvoiceAsync(Invoice invoice)
    {
        await _invoicesContext.Invoices.AddAsync(invoice);
        await _invoicesContext.SaveChangesAsync();
        return true;
    }
}
