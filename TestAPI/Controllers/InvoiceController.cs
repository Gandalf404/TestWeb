using Microsoft.AspNetCore.Mvc;
using TestAPI.Interfaces;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController(IInvoiceRepository invoiceRepository, IKitRepository kitRepository, IPartRepository partRepository) : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;
        private readonly IKitRepository _kitRepository = kitRepository;
        private readonly IPartRepository _partRepository = partRepository;

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

        [HttpPost("{kitId}, {partId}")]
        public async Task<IActionResult> PostInvoiceAsync(int kitId, int partId, Invoice invoice)
        {
            //TODO Создать методы для проверки существования комплекта и запчасти
            if (await _kitRepository.GetKitByIdAsync(kitId) != null && await _partRepository.GetPartByIdAsync(partId) != null)
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
            else 
            {
                return NotFound();
            }
        }
    }
}
