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

    public async Task<Invoice> GetInvoiceByIdAsync(int invoiceId)
    {
        return await _invoicesContext.Invoices.FirstOrDefaultAsync(c => c.InvoiceId == invoiceId);
    }

    public async Task<bool> PostInvoiceAsync(Invoice invoice)
    {
        invoice.Kit = _invoicesContext.Kits.FirstOrDefault(c => c.KitId == invoice.KitId);
        invoice.Part = _invoicesContext.Parts.FirstOrDefault(c => c.PartId == invoice.PartId);
        await _invoicesContext.Invoices.AddAsync(invoice);
        await _invoicesContext.SaveChangesAsync();
        return true;
    }
}
