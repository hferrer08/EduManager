using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduManagerAPI.Data;
using EduManagerAPI.Models;

namespace EduManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaEvaluacionController : ControllerBase
    {
        private readonly AppCoreDbContext _context;

        public EvaEvaluacionController(AppCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/EvaEvaluacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaEvaluacion>>> GetEvaluaciones()
        {
            return await _context.EvaEvaluacions.ToListAsync();
        }

        // GET: api/EvaEvaluacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaEvaluacion>> GetEvaluacion(int id)
        {
            var evaluacion = await _context.EvaEvaluacions.FindAsync(id);

            if (evaluacion == null)
            {
                return NotFound();
            }

            return evaluacion;
        }

        // POST: api/EvaEvaluacion
        [HttpPost]
        public async Task<ActionResult<EvaEvaluacion>> PostEvaluacion(EvaEvaluacion evaluacion)
        {
            _context.EvaEvaluacions.Add(evaluacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvaluacion), new { id = evaluacion.EvaluacionId }, evaluacion);
        }

        // PUT: api/EvaEvaluacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluacion(int id, EvaEvaluacion evaluacion)
        {
            if (id != evaluacion.EvaluacionId)
            {
                return BadRequest();
            }

            _context.Entry(evaluacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.EvaEvaluacions.Any(e => e.EvaluacionId == id))
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

        // DELETE: api/EvaEvaluacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluacion(int id)
        {
            var evaluacion = await _context.EvaEvaluacions.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            _context.EvaEvaluacions.Remove(evaluacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
