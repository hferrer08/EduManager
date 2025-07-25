using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduManagerAPI.Data;
using EduManagerAPI.Models;

namespace EduManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly AppCoreDbContext _context;

        public CursosController(AppCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurCurso>>> GetCursos()
        {
            return await _context.CurCursos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CurCurso>> GetCurso(int id)
        {
            var curso = await _context.CurCursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        [HttpPost]
        public async Task<ActionResult<CurCurso>> PostCurso(CurCurso curso)
        {
            _context.CurCursos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCurso), new { id = curso.Cursoid }, curso);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, CurCurso curso)
        {
            if (id != curso.Cursoid)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CurCursos.Any(e => e.Cursoid == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.CurCursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.CurCursos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }









    }
}