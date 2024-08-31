using Microsoft.AspNetCore.Mvc;
using TestAPI.Interfaces;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController(IInvoiceRepository invoiceRepository) : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;

        [HttpGet]
        public async Task<List<Invoice>> GeInvoicesAsync() 
        {
            return await _invoiceRepository.GetInvoicesAsync();
        }

        [HttpGet("{id}")]
        public async Task<Invoice> GetInvoiceByIdAsync(int id) 
        {
            return await _invoiceRepository.GetInvoiceByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> PostInvoiceAsync(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                await _invoiceRepository.PostInvoiceAsync(invoice);
                return Ok(invoice);
            }
            else 
            {
                return BadRequest("Ошибка при добавлении заказа");
            }
        }
    }
}
