using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Invoice>> GeInvoicesAsync() 
        {
            return await TestDb.invoicesContext.Invoices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Invoice> GetInvoiceByIdAsync(int id) 
        {
            return await TestDb.invoicesContext.Invoices.FirstOrDefaultAsync(c => c.InvoiceId == id);
        }

        [HttpPost]
        public async Task<IActionResult> PostInvoiceAsync(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                await TestDb.invoicesContext.Invoices.AddAsync(invoice);
                await TestDb.invoicesContext.SaveChangesAsync();
                return CreatedAtAction("Заказ добавлен", new { invoice.InvoiceId }, invoice);
            }
            else 
            {
                return new JsonResult("Ошибка при добавлении заказа") { StatusCode = 500 };
            }
        }
    }
}
