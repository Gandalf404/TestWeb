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
        public async Task<List<Kit>> GetKitsAsync() 
        {
            return await _kitRepository.GetKitsAsync();
        } 
        
        [HttpGet("{id}")]
        public async Task<Kit> GetKitByIdAsync(int id) 
        {
            return await _kitRepository.GetKitByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> PostKitAsync(Kit kit)
        {
            if (ModelState.IsValid)
            {
                await _kitRepository.PostKitAsync(kit);
                return Ok(kit);
            }
            else
            {
                return BadRequest("Ошибка при добавлении комплекта");
            }
        }
    }
}
