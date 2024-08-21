using AdministradorTareasHeinerUrenaZunigaAPI.DBContext;
using AdministradorTareasHeinerUrenaZunigaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministradorTareasHeinerUrenaZunigaAPI.Controllers
{
    [Route("api/[controller]")]

    public class TareasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TareasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            var tareas = await _context.Tareas
                      .Include(t => t.Colaborador) 
                      .OrderBy(t => t.FechaInicio)
                      .ToListAsync();

           
            var result = tareas.Select(t => new
            {
                t.Id,
                t.Descripcion,
                ColaboradorNombre = t.Colaborador != null ? t.Colaborador.Nombre : null,
                Estado = t.Estado switch
                {
                    0 => "Pendiente",
                    1 => "En Proceso",
                    2 => "Finalizada",
                    _ => "Desconocido" 
                },
                t.FechaInicio,
                t.FechaFinalizacion,
                t.Notas
            });

            return Ok(result);
        }

        // GET: api/Tareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return tarea;
        }

        // PUT: api/Tareas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(int id, [FromBody] Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Tarea actualizada con éxito." });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaExists(id))
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

        // POST: api/Tareas
        [HttpPost]
        public async Task<ActionResult<Tarea>> PostTarea([FromBody] Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest("Tarea no puede ser nula.");
            }
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
        }

        // DELETE: api/Tareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TareaExists(int id)
        {
            return _context.Tareas.Any(e => e.Id == id);
        }
    }
}
