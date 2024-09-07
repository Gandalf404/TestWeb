using Microsoft.AspNetCore.Mvc;
using TestAPI.Interfaces;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitController(IKitRepository kitRepository) : ControllerBase
    {
        private readonly IKitRepository _kitRepository = kitRepository;

        [HttpGet]
        public async Task<IActionResult> GetKitsAsync() 
        {
            return Ok(await _kitRepository.GetKitsAsync());
        } 
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKitByIdAsync(int id) 
        {
            if (await _kitRepository.GetKitByIdAsync(id) != null)
            {
                return Ok(await _kitRepository.GetKitByIdAsync(id));
            }
            else
            {
                return NotFound($"Комплект с идентификатором {id} не найден");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostKitAsync(Kit kit)
        {
            if (ModelState.IsValid)
            {
                await _kitRepository.CreateKitAsync(kit);
                return Ok(kit);
            }
            else
            {
                return BadRequest("Ошибка при добавлении комплекта");
            }
        }
    }
}
