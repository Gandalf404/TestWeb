using TestAPI.Models;

namespace TestAPI.Interfaces;

public interface IInvoiceRepository
{
    public Task<List<Invoice>> GetInvoicesAsync();
    public Task<Invoice> GetInvoiceByIdAsync(int invoiceId);
    public Task<bool> PostInvoiceAsync(Invoice invoice);
}
