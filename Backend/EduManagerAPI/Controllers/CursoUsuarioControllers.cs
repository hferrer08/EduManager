using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduManagerAPI.Data;
using EduManagerAPI.Models;

namespace EduManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurCursoUsuarioController : ControllerBase
    {
        private readonly AppCoreDbContext _context;

        public CurCursoUsuarioController(AppCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/CurCursoUsuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurCursoUsuario>>> GetCursoUsuarios()
        {
            return await _context.CurCursoUsuarios.ToListAsync();
        }

        // GET: api/CurCursoUsuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurCursoUsuario>> GetCursoUsuario(int id)
        {
            var cursoUsuario = await _context.CurCursoUsuarios.FindAsync(id);

            if (cursoUsuario == null)
            {
                return NotFound();
            }

            return cursoUsuario;
        }

        // POST: api/CurCursoUsuario
        [HttpPost]
        public async Task<ActionResult<CurCursoUsuario>> PostCursoUsuario(CurCursoUsuario cursoUsuario)
        {
            _context.CurCursoUsuarios.Add(cursoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCursoUsuario), new { id = cursoUsuario.CursoUsuarioId }, cursoUsuario);
        }

        // PUT: api/CurCursoUsuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursoUsuario(int id, CurCursoUsuario cursoUsuario)
        {
            if (id != cursoUsuario.CursoUsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(cursoUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CurCursoUsuarios.Any(e => e.CursoUsuarioId == id))
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

        // DELETE: api/CurCursoUsuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursoUsuario(int id)
        {
            var cursoUsuario = await _context.CurCursoUsuarios.FindAsync(id);
            if (cursoUsuario == null)
            {
                return NotFound();
            }

            _context.CurCursoUsuarios.Remove(cursoUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
