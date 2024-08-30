using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Part>> GetPartsAsync() 
        {
            return await TestDb.invoicesContext.Parts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Part> GetPartByIdAsync(int id) 
        {
            return await TestDb.invoicesContext.Parts.FirstOrDefaultAsync(c => c.PartId == id);
        }

        [HttpPost]
        public async Task<IActionResult> PostPartAsync(Part part)
        {
            if (ModelState.IsValid)
            {
                await TestDb.invoicesContext.Parts.AddAsync(part);
                await TestDb.invoicesContext.SaveChangesAsync();
                return CreatedAtAction("Part added", new { part.PartId }, part);
            }
            else
            {
                return new JsonResult("Model incorrect") { StatusCode = 500 };
            }
        }
    }
}
