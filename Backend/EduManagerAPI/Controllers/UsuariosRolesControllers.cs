using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduManagerAPI.Data;
using EduManagerAPI.Models;

namespace EduManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosRolesController : ControllerBase
    {
        private readonly AppCoreDbContext _context;

        public UsuariosRolesController(AppCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/usuariosroles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuUsuarioRol>>> GetUsuariosRoles()
        {
            return await _context.UsuUsuarioRoles
                                 .Include(ur => ur.Usuario)
                                 .Include(ur => ur.Rol)
                                 .ToListAsync();
        }

        // GET: api/usuariosroles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuUsuarioRol>> GetUsuarioRol(int id)
        {
            var usuarioRol = await _context.UsuUsuarioRoles
                                           .Include(ur => ur.Usuario)
                                           .Include(ur => ur.Rol)
                                           .FirstOrDefaultAsync(ur => ur.UsuarioRolId == id);

            if (usuarioRol == null)
            {
                return NotFound();
            }

            return usuarioRol;
        }

        // POST: api/usuariosroles
        [HttpPost]
        public async Task<ActionResult<UsuUsuarioRol>> PostUsuarioRol(UsuUsuarioRol usuarioRol)
        {
            _context.UsuUsuarioRoles.Add(usuarioRol);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarioRol), new { id = usuarioRol.UsuarioRolId }, usuarioRol);
        }

        // PUT: api/usuariosroles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioRol(int id, UsuUsuarioRol usuarioRol)
        {
            if (id != usuarioRol.UsuarioRolId)
            {
                return BadRequest();
            }

            _context.Entry(usuarioRol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UsuUsuarioRoles.Any(e => e.UsuarioRolId == id))
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

        // DELETE: api/usuariosroles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioRol(int id)
        {
            var usuarioRol = await _context.UsuUsuarioRoles.FindAsync(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            _context.UsuUsuarioRoles.Remove(usuarioRol);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
