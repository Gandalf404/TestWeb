using Microsoft.AspNetCore.Mvc;
using TestAPI.Interfaces;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController(IPartRepository partRepository) : ControllerBase
    {
        private readonly IPartRepository _partRepository = partRepository;

        [HttpGet]
        public async Task<IActionResult> GetPartsAsync() 
        {
            return Ok(await _partRepository.GetPartsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartByIdAsync(int id) 
        {
            if (await _partRepository.GetPartByIdAsync(id) != null) 
            {
                return Ok(await _partRepository.GetPartByIdAsync(id));
            }
            else
            {
                return NotFound($"Запчасть с идентификатором {id} не найдена");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPartAsync(Part part)
        {
            if (ModelState.IsValid)
            {
                await _partRepository.CreatePartAsync(part);
                return Ok(part);
            }
            else
            {
                return BadRequest("Ошибка при добавлении запчасти");
            }
        }
    }
}
