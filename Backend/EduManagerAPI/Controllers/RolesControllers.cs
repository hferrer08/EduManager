using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduManagerAPI.Data;
using EduManagerAPI.Models;

namespace EduManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly AppCoreDbContext _context;

        public RolesController(AppCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolRol>>> GetRoles()
        {
            return await _context.RolRoles.ToListAsync();
        }

        // GET: api/roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolRol>> GetRol(int id)
        {
            var rol = await _context.RolRoles.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return rol;
        }

        // POST: api/roles
        [HttpPost]
        public async Task<ActionResult<RolRol>> PostRol(RolRol rol)
        {
            _context.RolRoles.Add(rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRol), new { id = rol.Rolid }, rol);
        }

        // PUT: api/roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, RolRol rol)
        {
            if (id != rol.Rolid)
            {
                return BadRequest();
            }

            _context.Entry(rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RolRoles.Any(e => e.Rolid == id))
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

        // DELETE: api/roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var rol = await _context.RolRoles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            _context.RolRoles.Remove(rol);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
