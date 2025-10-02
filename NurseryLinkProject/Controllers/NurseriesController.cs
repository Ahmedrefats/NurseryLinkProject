using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLink.Data;
using NurseryLink.Models;

namespace NurseryLink.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NurseriesController : ControllerBase
    {
        private readonly NurseryContext _context;

        public NurseriesController(NurseryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Nurseries.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.Nurseries.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Nursery nursery)
        {
            _context.Nurseries.Add(nursery);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = nursery.Id }, nursery);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Nursery nursery)
        {
            if (id != nursery.Id) return BadRequest();
            _context.Entry(nursery).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Nurseries.FindAsync(id);
            if (item == null) return NotFound();
            _context.Nurseries.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
