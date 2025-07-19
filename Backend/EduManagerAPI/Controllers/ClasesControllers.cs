using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduManagerAPI.Data;
using EduManagerAPI.Models;

namespace EduManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaClaseController : ControllerBase
    {
        private readonly AppCoreDbContext _context;

        public ClaClaseController(AppCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ClaClase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaClase>>> GetClases()
        {
            return await _context.ClaClases.ToListAsync();
        }

        // GET: api/ClaClase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClaClase>> GetClase(int id)
        {
            var clase = await _context.ClaClases.FindAsync(id);

            if (clase == null)
            {
                return NotFound();
            }

            return clase;
        }

        // POST: api/ClaClase
        [HttpPost]
        public async Task<ActionResult<ClaClase>> PostClase(ClaClase clase)
        {
            _context.ClaClases.Add(clase);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClase), new { id = clase.ClaseId }, clase);
        }

        // PUT: api/ClaClase/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClase(int id, ClaClase clase)
        {
            if (id != clase.ClaseId)
            {
                return BadRequest();
            }

            _context.Entry(clase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ClaClases.Any(e => e.ClaseId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ClaClase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClase(int id)
        {
            var clase = await _context.ClaClases.FindAsync(id);
            if (clase == null)
            {
                return NotFound();
            }

            _context.ClaClases.Remove(clase);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
