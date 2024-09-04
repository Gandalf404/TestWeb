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
        public async Task<IActionResult> GeInvoicesAsync() 
        {
            return Ok(await _invoiceRepository.GetInvoicesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceByIdAsync(int id) 
        {
            if (await _invoiceRepository.GetInvoiceByIdAsync(id) != null) 
            {
                return Ok(await _invoiceRepository.GetInvoiceByIdAsync(id));
            }
            else
            {
                return NotFound($"Заказ с идентификатором {id} не найден");
            }
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
