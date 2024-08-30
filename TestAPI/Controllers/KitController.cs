using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Kit>> GetKitsAsync() 
        {
            return await TestDb.invoicesContext.Kits.ToListAsync();
        } 
        
        [HttpGet("{id}")]
        public async Task<Kit> GetKitByIdAsync(int id) 
        {
            return await TestDb.invoicesContext.Kits.FirstOrDefaultAsync(c => c.KitId == id);
        }

        [HttpPost]
        public async Task<IActionResult> PostKitAsync(Kit kit)
        {
            if (ModelState.IsValid)
            {
                await TestDb.invoicesContext.Kits.AddAsync(kit);
                await TestDb.invoicesContext.SaveChangesAsync();
                return CreatedAtAction("Комплект добавлен", new { kit.KitId }, kit);
            }
            else
            {
                return new JsonResult("Ошибка при добавлении") { StatusCode = 500 };
            }
        }
    }
}
