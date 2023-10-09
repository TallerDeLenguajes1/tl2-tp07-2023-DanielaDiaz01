
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tareas;
[Route("api/tareas")]
[ApiController]
public class TareasController : ControllerBase
{
    private readonly ManejoDeTareas manejoDeTareas;

    public TareasController()
    {
        manejoDeTareas = new ManejoDeTareas(); // Instancia de la clase de ManejoDeTareas
    }

    // Endpoint para crear una nueva tarea

    [HttpPost("CrearTarea")]
    public async Task<IActionResult> CrearTarea([FromBody] Tarea nuevaTarea)
    {
        if (nuevaTarea == null)
        {
            return BadRequest("La tarea no puede ser nula.");
        }

        await manejoDeTareas.GuardarTareaAsync(nuevaTarea);
        return CreatedAtAction(nameof(ObtenerTareaPorId), new { id = nuevaTarea.IdTarea }, nuevaTarea);
    }

    // Endpoint para obtener una tarea por id
    [HttpGet("ObtenerTareaPorId{id}")]
    public async Task<IActionResult> ObtenerTareaPorId(int id)
    {
        var tarea = await manejoDeTareas.ObtenerTareaPorIdAsync(id);
        if (tarea == null)
        {
            return NotFound();
        }
        return Ok(tarea);
    }

    // Endpoint para actualizar una tarea
    [HttpPut("ActualizarTarea{id}")]
    public async Task<IActionResult> ActualizarTarea(int id, [FromBody] Tarea tareaActualizada)
    {
        var tareaExistente = await manejoDeTareas.ObtenerTareaPorIdAsync(id);
        if (tareaExistente == null)
        {
            return NotFound();
        }

        tareaActualizada.IdTarea = id; // Asegurar que el ID coincida
        await manejoDeTareas.ActualizarTareaAsync(tareaActualizada);

        return NoContent();
    }

    // Endpoint para eliminar una tarea
    [HttpDelete("EliminarTareaPorId{id}")]
    public async Task<IActionResult> EliminarTarea(int id)
    {
        var tareaExistente = await manejoDeTareas.ObtenerTareaPorIdAsync(id);
        if (tareaExistente == null)
        {
            return NotFound();
        }

        await manejoDeTareas.EliminarTareaAsync(id);

        return NoContent();
    }

    // Endpoint para listar todas las tareas
    [HttpGet("ListarTodasLasTareas")]
    public async Task<IActionResult> ListarTodasLasTareas()
    {
        var tareas = await manejoDeTareas.ObtenerTodasLasTareasAsync();
        return Ok(tareas);
    }

    // Endpoint para listar todas las tareas completadas
    [HttpGet("ListarTodasLasTareasCompletadas")]
    public async Task<IActionResult> ListarTodasLasTareasCompletadas()
    {
        var tareasCompletadas = await manejoDeTareas.ObtenerTodasLasTareasCompletadasAsync();
        return Ok(tareasCompletadas);
    }
}


/*
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TuProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ManejoDeTareas manejoDeTareas;

        public TareasController(ManejoDeTareas manejoDeTareas)
        {
            this.manejoDeTareas = manejoDeTareas;
        }

        // POST: api/Tareas
        [HttpPost]
        public IActionResult CrearTarea([FromBody] Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest("Los datos de la tarea son inválidos.");
            }

            manejoDeTareas.AgregarTarea(tarea);
            return CreatedAtAction("ObtenerTareaPorId", new { id = tarea.IdTarea }, tarea);
        }

        // GET: api/Tareas/{id}
        [HttpGet("{id}", Name = "ObtenerTareaPorId")]
        public IActionResult ObtenerTareaPorId(int id)
        {
            var tarea = manejoDeTareas.ObtenerTareaPorId(id);

            if (tarea == null)
            {
                return NotFound("Tarea no encontrada.");
            }

            return Ok(tarea);
        }

        // PUT: api/Tareas/{id}
        [HttpPut("{id}")]
        public IActionResult ActualizarTarea(int id, [FromBody] Tarea tarea)
        {
            if (tarea == null || tarea.IdTarea != id)
            {
                return BadRequest("Los datos de la tarea son inválidos.");
            }

            var tareaExistente = manejoDeTareas.ObtenerTareaPorId(id);

            if (tareaExistente == null)
            {
                return NotFound("Tarea no encontrada.");
            }

            manejoDeTareas.ActualizarTarea(tarea);
            return NoContent();
        }

        // DELETE: api/Tareas/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarTarea(int id)
        {
            var tareaExistente = manejoDeTareas.ObtenerTareaPorId(id);

            if (tareaExistente == null)
            {
                return NotFound("Tarea no encontrada.");
            }

            manejoDeTareas.EliminarTarea(id);
            return NoContent();
        }

        // GET: api/Tareas
        [HttpGet]
        public IActionResult ListarTodasLasTareas()
        {
            var tareas = manejoDeTareas.ObtenerTodasLasTareas();
            return Ok(tareas);
        }

        // GET: api/Tareas/completadas
        [HttpGet("completadas")]
        public IActionResult ListarTodasLasTareasCompletadas()
        {
            var tareasCompletadas = manejoDeTareas.ObtenerTodasLasTareasCompletadas();
            return Ok(tareasCompletadas);
        }

    }
}
*/