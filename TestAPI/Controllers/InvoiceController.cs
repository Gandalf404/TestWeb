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

        [HttpPost]
        public async Task<IActionResult> PostInvoiceAsync(Invoice invoice)
        {
            if (await _kitRepository.IsKitExist(invoice.KitId))
            {
                if (await _partRepository.IsPartExist(invoice.PartId))
                {
                    if (ModelState.IsValid)
                    {
                        await _invoiceRepository.CreateInvoiceAsync(invoice);
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
            else 
            {
                return NotFound();
            }
        }
    }
}
