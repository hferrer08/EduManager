using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduManagerAPI.Data;
using EduManagerAPI.Models;

namespace EduManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaNotumController : ControllerBase
    {
        private readonly AppCoreDbContext _context;

        public EvaNotumController(AppCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/EvaNotum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaNotum>>> GetNotas()
        {
            return await _context.EvaNota.ToListAsync();
        }

        // GET: api/EvaNotum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaNotum>> GetNota(int id)
        {
            var nota = await _context.EvaNota.FindAsync(id);

            if (nota == null)
            {
                return NotFound();
            }

            return nota;
        }

        // POST: api/EvaNotum
        [HttpPost]
        public async Task<ActionResult<EvaNotum>> PostNota(EvaNotum nota)
        {
            _context.EvaNota.Add(nota);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNota), new { id = nota.NotaId }, nota);
        }

        // PUT: api/EvaNotum/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNota(int id, EvaNotum nota)
        {
            if (id != nota.NotaId)
            {
                return BadRequest();
            }

            _context.Entry(nota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.EvaNota.Any(e => e.NotaId == id))
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

        // DELETE: api/EvaNotum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            var nota = await _context.EvaNota.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }

            _context.EvaNota.Remove(nota);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
